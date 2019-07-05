using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuS.Persistence;

namespace SuS.Application.BranchManager.Query.GetBranch
{
    public class GetBranchQueryHandler: IRequestHandler<GetBranchQuery, GetBranchViewModel>
    {


        private readonly SupplierDbContext _context;
        private readonly IMapper _mapper;
        public GetBranchQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        
        
        public async Task<GetBranchViewModel> Handle(GetBranchQuery request, CancellationToken cancellationToken)
        {
            var BranchData =  _context.Branch
                .Include(x => x.Supplier).ThenInclude(x => x.AlternateName)
                .Include(x => x.Supplier).ThenInclude(x => x.Type)
                .Include(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Region)
                .SingleOrDefault(x =>
                    x.Number.Equals(request.BranchNumber) &&
                    (x.Supplier.Name.Equals(request.SupplierName, StringComparison.InvariantCultureIgnoreCase) ||
                     x.Supplier.Number.Equals(request.SupplierNumber)));

            return _mapper.Map<GetBranchViewModel>(BranchData);
        }
    }
}