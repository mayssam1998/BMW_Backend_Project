using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.Interfaces.Models
{
    public partial class CountryViewModel
    {
        public string Name { get; set; }
        public string Iso3 { get; set; }
        public string Iso2 { get; set; }
        public RegionViewModel Region { get; set; }
    }
}
