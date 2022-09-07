using InfinityMesh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using CsvHelper;
using System.Globalization;
using InfinityMesh.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace InfinityMesh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly ElectionContext _db;
        public ResultController(ElectionContext _db)
        {
            this._db = _db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await _db.Votes.ToListAsync();
            return Ok(news);
        }


        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            #region Upload CSV
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

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
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while(csv.Read())
                {
                    var vote = csv.GetRecord<Votes>();
                    votes.Add(vote);
                }
            }
            #endregion

            return votes;

        }


    }
}

