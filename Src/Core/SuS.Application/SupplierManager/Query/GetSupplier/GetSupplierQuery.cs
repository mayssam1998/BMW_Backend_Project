using MediatR;

namespace SuS.Application.SupplierManager.Query.GetSupplier
{
    public class GetSupplierQuery: IRequest<GetSupplierViewModel>
    {
        public string SupplierSearch { get; set; }
        
    }
}