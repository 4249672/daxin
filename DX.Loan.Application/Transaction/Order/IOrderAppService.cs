using Abp.Application.Services.Dto;
using DX.Loan.Transaction.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order
{
    public interface IOrderAppService
    {

        List<GetOrdersListDto> GetOrdersList(GetOrdersInput input);

        GetOrderDto GetOrder(EntityDto<long> input);

        Task<bool> CreateOrder(CreateOrderInput input);

    }
}
