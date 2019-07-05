using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.Interfaces.Models
{
    public partial class BranchViewModel
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public StreetViewModel Street { get; set; }
    }
}
