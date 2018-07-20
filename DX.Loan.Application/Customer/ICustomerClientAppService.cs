using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Friendships.Dto;
using Abp.Application.Services.Dto;
using DX.Loan.Customer.Dto;

namespace DX.Loan.Customer
{
    //专门给用户操作的
    public interface ICustomerClientAppService : IApplicationService
    {

        PagedResultDto<CustomerForUserPageDto> GetCustomersForUserByList(SearchCustomerForUserInput input);

    }
}
