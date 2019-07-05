using MediatR;

namespace SuS.Application.BranchManager.Query.GetBranch
{
    public class GetBranchQuery: IRequest<GetBranchViewModel>
    {
        public string SupplierNumber { get; set; }
        public string SupplierName { get; set; }
        public string BranchNumber { get; set; }
    }
}