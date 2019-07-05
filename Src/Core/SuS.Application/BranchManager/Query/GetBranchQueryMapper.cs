using AutoMapper;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.BranchManager.Query.GetBranch
{
    public class GetBranchQueryMapper: Profile
    {
        public GetBranchQueryMapper()
        {
            CreateMap<Branch, GetBranchViewModel>().ReverseMap();
            CreateMap<Supplier, GetBranchSupplierViewModel>().ReverseMap();
            
            
        }
    }
}