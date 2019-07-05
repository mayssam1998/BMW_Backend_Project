using SuS.Application.Interfaces.Models;

namespace SuS.Application.BranchManager.Query.GetBranch
{
    public class GetBranchViewModel: BranchViewModel
    {
        public GetBranchSupplierViewModel Supplier { get; set; }
    }
}