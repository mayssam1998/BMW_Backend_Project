using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.Interfaces.Models
{
    public partial class CityViewModel
    {
        public string Name { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
