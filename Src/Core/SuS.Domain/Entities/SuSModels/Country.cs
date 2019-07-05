using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public long? RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<City> City { get; set; }
    }
}
