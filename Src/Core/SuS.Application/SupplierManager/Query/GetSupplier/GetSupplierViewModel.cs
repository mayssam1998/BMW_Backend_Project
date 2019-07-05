using System.Collections.Generic;
using SuS.Application.Interfaces.Models;

namespace SuS.Application.SupplierManager.Query.GetSupplier
{
    public class GetSupplierViewModel
    {
        public List<SupplierViewModel> supplierList { get; set; }
        public int supplierCount { get; set; }
    }
}