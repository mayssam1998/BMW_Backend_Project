using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuS.Application.Interfaces.Models;
using SuS.Domain.Entities.SuSModels;
using SuS.Persistence;

namespace SuS.Application.SupplierManager.Query.GetSupplier
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, GetSupplierViewModel>
    {
        private readonly SupplierDbContext _context;
        private IMapper _mapper;

        public GetSupplierQueryHandler(SupplierDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSupplierViewModel> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            var supplierList = new HashSet<Supplier>();
            
            await _context.AlternateName.Include(x => x.Supplier)
                .ThenInclude(x => x.AlternateName)
                .Include(x => x.Supplier)
                .ThenInclude(x => x.Type)
                .Include(x => x.Supplier)
                .ThenInclude(x => x.Branch)
                .ThenInclude(x => x.Street)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .ThenInclude(x => x.Region)
                .Where(x => !string.IsNullOrEmpty(request.SupplierSearch)
                            && (x.Name.Contains(request.SupplierSearch, StringComparison.InvariantCultureIgnoreCase)
                                || x.Supplier.Type.Name.Contains(request.SupplierSearch,
                                    StringComparison.InvariantCultureIgnoreCase)
                                || x.Supplier.Name.Contains(request.SupplierSearch,
                                    StringComparison.InvariantCultureIgnoreCase)
                                || x.Supplier.Number.Contains(request.SupplierSearch,
                                    StringComparison.InvariantCultureIgnoreCase)))
                .ForEachAsync(x => supplierList.Add(x.Supplier), cancellationToken);
            
            

            return new GetSupplierViewModel
            {
                supplierList = _mapper.Map<List<SupplierViewModel>>(supplierList),
                supplierCount = supplierList.Count()
            };
        }
    }
}