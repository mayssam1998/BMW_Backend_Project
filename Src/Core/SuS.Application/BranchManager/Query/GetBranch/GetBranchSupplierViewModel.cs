using System.Collections.Generic;
using SuS.Application.Interfaces.Models;

namespace SuS.Application.BranchManager.Query.GetBranch
{
    public class GetBranchSupplierViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public long? TypeId { get; set; }

        public TypeViewModel Type { get; set; }
        public List<AlternateNameViewModel> AlternateName { get; set; }
    }
}