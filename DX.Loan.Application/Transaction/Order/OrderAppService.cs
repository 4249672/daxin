using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DX.Loan.CustomerMaint;
using DX.Loan.Trade;
using DX.Loan.Transaction.Order;
using DX.Loan.Transaction.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction
{
    public class OrderAppService : LoanAppServiceBase, IOrderAppService
    {
        private readonly ICustomerManager _customerManager;
        private readonly IRepository<DX.Loan.Order, long> _orderRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ITradeManager _tradeManager;

        [UnitOfWork]
        public async Task<bool> CreateOrder(CreateOrderInput input)
        {
            var customer = _customerManager.GetCustomer(input.CustomerId);
            if(customer == null)
                throw new UserFriendlyException("未找到对应订单信息,购买订单失败");

            long userId = AbpSession.GetUserId();

            var order = new DX.Loan.Order();
            order.Age = customer.Age;
            order.AppEquipment = customer.AppEquipment;
            order.ApplicationDate = customer.ApplicationDate;
            order.Area = customer.Area;
            order.CreditRating = customer.CreditRating;
            order.CustomerId = customer.Id;
            order.IdCard = customer.IdCard;
            order.Interest = customer.Interest;
            order.Name = customer.Name;
            order.QQ = customer.QQ;
            order.SesameScore = customer.SesameScore;
            order.Source = customer.Source;
            order.Tel = customer.Tel;
            order.WeChat = customer.WeChat;
            order.OrderAmount = customer.RecordCharge??0;//价格

            order.OrderNo = GenerateOrderNo(OrderType.FK);
            order.Status = OrderType.FK.ToString(); //已付款
            order.UserId = userId;

            await _orderRepository.InsertAsync(order);
            await _tradeManager.CreateTradeForOrderAsync(customer.RecordCharge ?? 0, customer.CustomerNo);

            return true;

        }

        public GetOrderDto GetOrder(EntityDto<long> input)
        {
            var order = _orderRepository.Get(input.Id);
            return Mapper.Map<GetOrderDto>(order);
        }

        public List<GetOrdersListDto> GetOrdersList(GetOrdersInput input)
        {
            
        }

        private string GenerateOrderNo(OrderType tradeType)
        {
            return UniqueNumber.GetUniqueNumber(tradeType.ToString());
        }

    }
}
