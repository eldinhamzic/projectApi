using CsvHelper.Configuration;

namespace InfinityMesh.Models
{
    public sealed class VotesMap : ClassMap<Votes>
    {
        public VotesMap()
        {
            

            Map(v => v.ConstituencyName).Index(0);
            int index = 0;
           for(int i = 0; i < index; i++)
            {
                Map().Index(i);
                index = i;
            }
            for(int i = 0; i<index; i++)
            {
                if (i / 2 != 0)
                {
                    Map(v => v.NumberOfVotes).Index(i);
                    Map(v => v.CandidateCode).Index(i + 1);
                }
            }

        }
    }
}
