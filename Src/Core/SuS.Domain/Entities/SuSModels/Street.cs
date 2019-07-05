using System.Collections.Generic;

namespace SuS.Domain.Entities.SuSModels
{
    public partial class Street
    {
        public Street()
        {
            Branch = new HashSet<Branch>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? CityId { get; set; }

        public City City { get; set; }
        public ICollection<Branch> Branch { get; set; }
    }
}
