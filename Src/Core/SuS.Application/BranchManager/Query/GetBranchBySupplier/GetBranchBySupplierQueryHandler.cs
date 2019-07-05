using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuS.Application.BranchManager.Query.GetBranch;
using SuS.Application.SupplierManager.Query.GetSupplier;
using SuS.Persistence;

namespace SuS.Application.BranchManager.Query.GetBranchBySupplier
{
    public class GetBranchBySupplierQueryHandler: IRequestHandler<GetBranchBySupplierQuery, List<GetBranchViewModel>>
    {
        
        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;
        public GetBranchBySupplierQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<List<GetBranchViewModel>> Handle(GetBranchBySupplierQuery request, CancellationToken cancellationToken)
        {
            var BranchData =  _context.Branch
                .Include(x => x.Supplier)
                .Where(x =>
                    (x.Supplier.Name.Equals(request.Supplier, StringComparison.InvariantCultureIgnoreCase)||x.Supplier.Number.Equals(request.Supplier, StringComparison.InvariantCultureIgnoreCase)));

            return _mapper.Map<List<GetBranchViewModel>>(BranchData);
        }
    }
}