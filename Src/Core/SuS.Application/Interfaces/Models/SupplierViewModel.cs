using System.Collections.Generic;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.Interfaces.Models
{
    public partial class SupplierViewModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public TypeViewModel Type { get; set; }
        public List<BranchViewModel> Branch { get; set; }
    }
}
