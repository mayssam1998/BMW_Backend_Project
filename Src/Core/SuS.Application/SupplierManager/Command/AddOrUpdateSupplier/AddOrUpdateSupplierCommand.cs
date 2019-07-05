using System.Collections.Generic;
using MediatR;
using SuS.Application.Interfaces.Models;
using SuS.Application.SupplierManager.Query.GetSupplier;
using SuS.Domain.Entities.SuSModels;

namespace SuS.Application.SupplierManager.Command.AddOrUpdateSupplier
{
    public class AddOrUpdateSupplierCommand : IRequest<SupplierViewModel>
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public List<string> AlternateName { get; set; } = new List<string>();
        
    }
}