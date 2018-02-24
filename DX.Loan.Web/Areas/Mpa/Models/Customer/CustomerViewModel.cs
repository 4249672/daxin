using Abp.AutoMapper;
using DX.Loan.Customer.Dto;
using DX.Loan.Web.Areas.Mpa.Models.Common;

namespace DX.Loan.Web.Areas.Mpa.Models.Customer
{
    [AutoMapFrom(typeof(CustomerEditDto))]
    public class CustomerViewModel: CustomerEditDto
    {
        public bool IsEditMode
        {
            get { return this.Id.HasValue; }
        }

        public CustomerViewModel(CustomerEditDto output) {
            output.MapTo(this);
        }

    }
}