using AutoMapper;
using SuS.Application.Interfaces.Models;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.SupplierManager.Query.GetSupplier
{
    public class GetSupplierMapper: Profile
    {

        public GetSupplierMapper()
        {
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Type, TypeViewModel>().ReverseMap();
            CreateMap<AlternateName, AlternateNameViewModel>().ReverseMap();
            CreateMap<Branch, BranchViewModel>().ReverseMap();
            CreateMap<Street, StreetViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Region, RegionViewModel>().ReverseMap();
        }
    }
}