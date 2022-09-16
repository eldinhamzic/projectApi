using InfinityMesh.Models;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.Globalization;
using InfinityMesh.DataAccess;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;

namespace InfinityMesh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {

        ElectionContext db = new ElectionContext();

        private readonly ElectionContext _db;

        public ResultController(ElectionContext _db)
        {
            this._db = _db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.Votes.ToListAsync();
            
            return Ok(data);
        }

       


        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"https://localhost:7116/api/Result/{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(fileName)) 
            {
                
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            #endregion
            var votes = this.GetVotesList(fileName);
            return Ok(votes);
        }

        private List<Votes> GetVotesList(string fileName)
        {
            List<Votes> votes = new List<Votes>();
            

            #region Read CSV

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };

            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path)) { 

                
              
                 using (var csv = new CsvReader(reader, csvConfig))
                {
                    string value;
                

                    
                    while(csv.Read())
                    {
                        
                        var vote = csv.GetRecord<Votes>();


                       
                        
                        Constituency constituency = db.Constituencies.Where(x => x.Name == vote.ConstituencyName).FirstOrDefault();
                        Candidate candidate = db.Candidates.Where(c => c.Code == vote.CandidateCode && constituency.Name == vote.ConstituencyName ).FirstOrDefault();

                       

                        if(candidate != null  && candidate.OverrideFile==true)
                        { 

                            vote.CandidateName =  candidate.FullName;  
                            candidate.AllVotes =  candidate.AllVotes + Int16.Parse(vote.NumberOfVotes);
                            vote.ConstituencyName = constituency.Name;
                            constituency.VotesFromConstituency = constituency.VotesFromConstituency + Int16.Parse(vote.NumberOfVotes);
                            vote.Constituency = constituency;
                            vote.Candidate = candidate;
                            vote.Percentage = (candidate.AllVotes / constituency.VotesFromConstituency) * 100;
                            vote.AllVotes = candidate.AllVotes + Int16.Parse(vote.NumberOfVotes); 

                        }
                        else
                        {
                            vote.NumberOfVotes = null;
                            vote.ConstituencyName = constituency.Name;
                            vote.CandidateName = candidate.FullName;
                            vote.Percentage = 0;
                        }
                        
                        votes.Add(vote);
                        
                       
                        
                    }
                 }
            }   
            #endregion

            return votes;

        }


    }
}

