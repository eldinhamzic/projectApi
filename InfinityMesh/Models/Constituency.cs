using System.ComponentModel.DataAnnotations;

namespace InfinityMesh.Models
{
    public class Constituency
    {
        public Constituency()
        {
            this.Votes = new HashSet<Votes>();
        }
        [Key]
        public int ConstituencyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Votes> Votes { get; set; }
    }
}
