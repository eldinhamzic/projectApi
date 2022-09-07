namespace InfinityMesh.Models
{
    public class Votes
    {
        public int Id { get; set; }
        public string? ConstituencyName { get; set; }
        public string? CandidateName { get; set; }
        public string? CandidateCode { get; set; }
        public int? NumberOfVotes { get; set; }
        public bool? OverrideFile { get; set; }

        public virtual Constituency Constituency { get; set; }
        public virtual Candidate Candidate { get; set; }


        

    }
}
