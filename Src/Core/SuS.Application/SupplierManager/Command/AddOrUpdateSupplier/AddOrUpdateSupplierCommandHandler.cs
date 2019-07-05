using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using MediatR;
using SuS.Application.Interfaces.Models;
using SuS.Application.SupplierManager.Query.GetSupplier;
using SuS.Domain.Entities.SuSModels;
using SuS.Persistence;
using Type = System.Type;

namespace SuS.Application.SupplierManager.Command.AddOrUpdateSupplier
{
    public class AddOrUpdateSupplierCommandHandler: IRequestHandler<AddOrUpdateSupplierCommand, SupplierViewModel>
    {
        
        private readonly SupplierDbContext _context;
        private IMapper _mapper;

        public AddOrUpdateSupplierCommandHandler(SupplierDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<SupplierViewModel> Handle(AddOrUpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            
            if (string.IsNullOrEmpty(request.Name)
                || string.IsNullOrEmpty(request.Type)
                || string.IsNullOrEmpty(request.Number) )return null;
            
            
            var existingSupplier = _context.Supplier.SingleOrDefault(
                x => x.Number.Equals(request.Number, StringComparison.InvariantCultureIgnoreCase));
            
            var existingType = _context.Type.SingleOrDefault(
                x => x.Name.Equals(request.Type, StringComparison.InvariantCultureIgnoreCase));
            ICollection<AlternateName> AlternateNamesArray=new List<AlternateName>();
            if (existingType == null)
            {
                existingType = _context.Type.Add(new Domain.Entities.SuSModels.Type()
                {
                    Name = request.Type
                }).Entity;
            }
            

            if (existingSupplier == null)
            {
                existingSupplier = _context.Supplier.Add(new Supplier
                {
                    Name = request.Name,
                    Number = request.Number,
                    Type = existingType,
                    

                }).Entity;
               
                request.AlternateName.ForEach(x=>
                {
                    AlternateNamesArray.Add(new AlternateName
                    {
                        Name = x,
                        SupplierId = existingSupplier.Id
                            
                    });
                });

            }
            else
            {
                
                existingSupplier.Name = request.Name;
                existingSupplier.Type.Name = request.Type;
                existingSupplier.AlternateName.ToList().ForEach(x =>
                {
                    request.AlternateName.ForEach(y =>
                        {
                            if (x.Name != y)
                            {
                                _context.AlternateName.Add(new AlternateName
                                {
                                    Name = y,
                                    SupplierId = x.Id
                                        
                                });
                            }
                        }
                        );
                });

            }

            try
            {

                _context.SaveChanges();

            }
            catch (Exception e)
            {
                return null;
            }
            
            
            return null;

        }
    }
}