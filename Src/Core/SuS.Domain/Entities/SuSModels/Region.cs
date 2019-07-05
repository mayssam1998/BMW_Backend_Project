using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class Region
    {
        public Region()
        {
            Country = new HashSet<Country>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Country> Country { get; set; }
    }
}
