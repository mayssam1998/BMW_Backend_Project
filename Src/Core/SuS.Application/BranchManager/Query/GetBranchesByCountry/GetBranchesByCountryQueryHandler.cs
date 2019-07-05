using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuS.Persistence;

namespace SuS.Application.BranchManager.Query.GetBranch.GetBranchesByCountry
{
    public class GetBranchesByCountryQueryHandler: IRequestHandler<GetBranchesByCountryQuery, List<GetBranchViewModel>>
    {
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;
        public GetBranchesByCountryQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<GetBranchViewModel>> Handle(GetBranchesByCountryQuery request, CancellationToken cancellationToken)
        {
            
            var BranchData =  _context.Branch
                .Include(x => x.Street)
                .Where(x =>
                    (x.Street.City.Country.Name.Equals(request.Country, StringComparison.InvariantCultureIgnoreCase)||x.Street.City.Country.Id.Equals(request.Country)));

            return _mapper.Map<List<GetBranchViewModel>>(BranchData);
        }
    }
}