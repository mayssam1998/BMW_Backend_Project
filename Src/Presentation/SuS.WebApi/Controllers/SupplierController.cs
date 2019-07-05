using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuS.Application.SupplierManager.Command.AddOrUpdateSupplier;
using SuS.Application.SupplierManager.Query.GetSupplier;

namespace SuS.WebApi.Controllers
{
    public class SupplierController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetSupplier(GetSupplierQuery supplierQuery)
        {
            return Ok(await Mediator.Send(supplierQuery));
        }



        [HttpPost]
        [Route("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdateSupplier([FromBody] AddOrUpdateSupplierCommand addOrUpdateSupplierCommand)
        {
            return Ok(await Mediator.Send(addOrUpdateSupplierCommand));
        }
    }
}