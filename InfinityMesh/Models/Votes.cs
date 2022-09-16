using CsvHelper.Configuration.Attributes;

namespace InfinityMesh.Models
{
    public class Votes
    {
        
       
        public Votes()
        {

        }
        public int Id { get; set; }
        [Index(0)]
        public string ConstituencyName { get; set; }
        public string CandidateName { get; set; }
        [Index(2)]
        public string CandidateCode { get; set; }
        [Index(1)]
        public string NumberOfVotes { get; set; }
        public int Percentage { get; set; }
        public int AllVotes { get; set; }


        public virtual Constituency Constituency { get; set; }
        public virtual Candidate Candidate { get; set; }


        
        


    }
}
