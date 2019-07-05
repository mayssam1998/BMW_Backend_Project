using System.Collections.Generic;
using MediatR;
using SuS.Application.BranchManager.Query.GetBranch;
using SuS.Application.SupplierManager.Query.GetSupplier;

namespace SuS.Application.BranchManager.Query.GetBranchBySupplier
{
    public class GetBranchBySupplierQuery : IRequest<List<GetBranchViewModel>>
    {
        public string Supplier { get; set; }
    }
}