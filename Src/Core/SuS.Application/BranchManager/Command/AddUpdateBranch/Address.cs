using SuS.Application.Interfaces.Models;

namespace SuS.Application.BranchManager.Command.AddUpdateBranch
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public CountryViewModel Country { get; set; } = new CountryViewModel();
    }
}