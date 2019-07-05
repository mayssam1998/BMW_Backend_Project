using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuS.Application.BranchManager.Command.AddUpdateBranch;
using SuS.Application.BranchManager.Query.GetBranch;
using SuS.Application.BranchManager.Query.GetBranch.GetBranchesByCountry;
using SuS.Application.BranchManager.Query.GetBranchAutocomplete;
using SuS.Application.BranchManager.Query.GetBranchBySupplier;
using SuS.Application.SupplierManager.Query.GetSupplier;


namespace SuS.WebApi.Controllers
{
    public class BranchController : BaseController
    {
        
        // Get Branch/
        [HttpGet]
                 public async Task<IActionResult> GetSupplier(GetBranchQuery branchQuery)
                 {
                     return Ok(await Mediator.Send(branchQuery));
                 }
        
        // Post Branch/Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddOrUpdateBranch(AddUpdateBranchCommand AddUpdateCommand)
        {
            var result =await Mediator.Send(AddUpdateCommand);
            if (result == null)
            {
                return BadRequest("Wrong Parameters");
            }

            return Ok(result);
        }
        
        // Get Branch/Autocomplete
        [HttpGet]
        [Route("Autocomplete")]
        public async Task<IActionResult> BranchAutocomplete(GetBranchAutocompleteQuery branchAutocompleteQuery)
        {
            var result =await Mediator.Send(branchAutocompleteQuery);
            if (result == null)
            {
                return BadRequest("Wrong Parameters");
            }

            return Ok(result);
        }
        
        // Get Branch by Supplier/
        [HttpGet]
        [Route("GetBySupplier")]
        
        public async Task<IActionResult> GetBranchBySupplier(GetBranchBySupplierQuery branchBySupplierQuery)
        {
            return Ok(await Mediator.Send(branchBySupplierQuery));
        }
        
        // Get Branch by Supplier/
        [HttpGet]
        [Route("GetByCountry")]
        
        public async Task<IActionResult> GetBranchByCountry(GetBranchesByCountryQuery branchesByCountryQuery)
        {
            return Ok(await Mediator.Send(branchesByCountryQuery));
        }
        

    }
}