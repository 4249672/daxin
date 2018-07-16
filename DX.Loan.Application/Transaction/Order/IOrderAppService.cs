using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DX.Loan.Transaction.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order
{
    public interface IOrderAppService : IApplicationService
    {

        PagedResultDto<GetOrdersListDto> GetOrdersList(GetOrdersInput input);

        GetOrderDto GetOrder(long userId,long Id);

        Task<bool> CreateOrder(CreateOrderInput input);

        //仅供用户
        PagedResultDto<GetOrdersListDto> GetOrdersListForUser(GetOrdersInput input);

        //仅供用户
        GetOrderDto GetOrderForUser(long Id);

    }
}
