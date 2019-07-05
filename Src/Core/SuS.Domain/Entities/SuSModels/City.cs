using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class City
    {
        public City()
        {
            Street = new HashSet<Street>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Street> Street { get; set; }
    }
}
