using InfinityMesh.Models;
using Microsoft.EntityFrameworkCore;

namespace InfinityMesh.DataAccess
{
    public class ElectionContext  : DbContext
    {

        public ElectionContext()
        {
        }

        public ElectionContext(DbContextOptions<ElectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<Constituency> Constituencies { get; set; } = null!;
        public virtual DbSet<Votes> Votes { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=ElectionDB;Integrated Security=True;");
            }
        }
    }
}
