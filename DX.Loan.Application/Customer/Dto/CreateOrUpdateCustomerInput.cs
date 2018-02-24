using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DX.Loan.Customer.Dto
{
    public class CreateOrUpdateCustomerInput
    {
        
        public CustomerEditDto Customer { get; set; }
    }
}
