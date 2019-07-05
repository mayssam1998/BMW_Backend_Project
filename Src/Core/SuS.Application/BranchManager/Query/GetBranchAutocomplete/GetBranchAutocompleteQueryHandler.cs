using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuS.Application.BranchManager.Query.GetBranch;
using SuS.Persistence;

namespace SuS.Application.BranchManager.Query.GetBranchAutocomplete
{
    public class GetBranchAutocompleteQueryHandler: IRequestHandler<GetBranchAutocompleteQuery, List<GetBranchViewModel>>
    {
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;
        public GetBranchAutocompleteQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<GetBranchViewModel>> Handle(GetBranchAutocompleteQuery request, CancellationToken cancellationToken)
        {
          
                var BranchData =  _context.Branch
                    
                    .Include(x => x.Supplier)
                    .Where(x =>
                        x.Number.Contains(request.branchSearch) || 
                        x.Supplier.Name.Contains(request.branchSearch, StringComparison.InvariantCultureIgnoreCase) ||
                         x.Supplier.Number.Contains(request.branchSearch))
                    .Include(x => x.Supplier).ThenInclude(x => x.Type)
                    .Include(x => x.Supplier).ThenInclude(x => x.AlternateName)
                    .Include(x => x.Street)
                    .ThenInclude(x => x.City)
                    .ThenInclude(x => x.Country)
                    .ThenInclude(x => x.Region);

                return _mapper.Map<List<GetBranchViewModel>>(BranchData);
            
        }
    }
}