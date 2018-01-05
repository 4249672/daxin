using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Customer;

namespace DX.Loan.Web.Areas.Mpa.Models.Customer
{
    public class CustomerListViewModel
    {
        public ListResultDto<CustomerDto> List { get; set; }
        
    }
}