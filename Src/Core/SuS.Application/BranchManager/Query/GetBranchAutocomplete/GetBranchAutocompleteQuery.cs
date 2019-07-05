using System.Collections.Generic;
using MediatR;
using SuS.Application.BranchManager.Query.GetBranch;

namespace SuS.Application.BranchManager.Query.GetBranchAutocomplete
{
    public class GetBranchAutocompleteQuery: IRequest<List<GetBranchViewModel>>
    {
        public string branchSearch { get; set; }
    }
}