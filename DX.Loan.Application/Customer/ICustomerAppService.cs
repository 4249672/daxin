using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Friendships.Dto;
using Abp.Application.Services.Dto;
using DX.Loan.Customer.Dto;

namespace DX.Loan.Customer
{
    public interface ICustomerAppService : IApplicationService
    {
        PagedResultDto<CustomerDto> GetCustomers(SearchCustomerInput input);

        void CreateOrUpdateCustomer(CreateOrUpdateCustomerInput input);

        CustomerEditDto GetCustomerForEdit(NullableIdDto input);

        void DeleteCustomer(EntityDto input);
        
    }
}
