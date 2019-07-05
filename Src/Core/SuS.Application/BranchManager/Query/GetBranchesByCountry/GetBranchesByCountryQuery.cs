using System.Collections.Generic;
using MediatR;

namespace SuS.Application.BranchManager.Query.GetBranch.GetBranchesByCountry
{
    public class GetBranchesByCountryQuery: IRequest<List<GetBranchViewModel>>
    {
        public string Country { get; set; }
    }
}