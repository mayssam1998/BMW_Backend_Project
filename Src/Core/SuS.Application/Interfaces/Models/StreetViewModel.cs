using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.Interfaces.Models
{
    public partial class StreetViewModel
    {
        public string Name { get; set; }
        public CityViewModel City { get; set; }
    }
}
