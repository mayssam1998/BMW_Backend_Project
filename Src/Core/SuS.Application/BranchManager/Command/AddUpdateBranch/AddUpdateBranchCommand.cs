using System.Collections.Generic;
using MediatR;
using SuS.Application.BranchManager.Query.GetBranch;

namespace SuS.Application.BranchManager.Command.AddUpdateBranch
{
    public class AddUpdateBranchCommand: IRequest<GetBranchViewModel>
    {
        public string supplierNumber { get; set; } = "";
        public string supplierName { get; set; } = "";
        public string supplierType { get; set; } = "";
        public List<string> supplierAlternateName { get; set; } = new List<string>();
        public string branchNumber { get; set; } = "";
        public string branchName { get; set; } = "";
        public string PostCode { get; set; } = "";
        public Address Address { get; set; } = new Address();
        
    }
}