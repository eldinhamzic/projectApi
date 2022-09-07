using System.ComponentModel.DataAnnotations;

namespace InfinityMesh.Models
{
    public class Candidate
    {
        public Candidate()
        {
            this.Votes = new HashSet<Votes>();
        }

        [Key]
        public int CandidateId { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int AllVotes { get; set; }

        public virtual ICollection<Votes> Votes { get; set; }

    }
}
