using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DX.Loan.CustomerMaint;
using DX.Loan.IRepositories;
using DX.Loan.Trade;
using DX.Loan.Transaction.Order;
using DX.Loan.Transaction.Order.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace DX.Loan.Transaction
{
    public class OrderAppService : LoanAppServiceBase, IOrderAppService
    {
        private readonly ICustomerManager _customerManager;
        private readonly IOrderRepository _orderRepository;
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

        public GetOrderDto GetOrder(long userId,long Id)
        {
            var order = _orderRepository.GetOneOrderForUser(userId, Id);
            return Mapper.Map<GetOrderDto>(order);
        }
        public GetOrderDto GetOrderForUser(long Id)
        {
            long userId = AbpSession.GetUserId();
            var order = _orderRepository.GetOneOrderForUser(userId, Id);
            return Mapper.Map<GetOrderDto>(order);
        }

        public PagedResultDto<GetOrdersListDto> GetOrdersList(GetOrdersInput input)
        {
            long userId = input.UserID;
            var dbSrc = _orderRepository.GetOrdersForUser(input.UserID).WhereIf(input.OrderNo.IsNullOrWhiteSpace(), m => m.OrderNo == input.OrderNo)
                                                           .WhereIf(input.OrderStartDate.HasValue, m => m.CreationTime >= input.OrderStartDate)
                                                           .WhereIf(input.OrderEndDate.HasValue, m => m.CreationTime <= input.OrderEndDate)
                                                           .WhereIf(input.Status.IsNullOrWhiteSpace(), m => m.Status == input.Status)
                                                           .OrderBy(input.Sorting);

            string startDate = (input.OrderStartDate ?? DateTime.MinValue).ToShortTimeString();
            string endDate = (input.OrderEndDate ?? DateTime.MinValue).ToShortTimeString();
            var cacheKey = @"GetOrdersList_{userId.ToString()}_{startDate}_{endDate}_{input.TradeType}";

            var list =
                _cacheManager.GetCache<string, List<DX.Loan.Order>>(AppConsts.Cache_OrderAppService_Method_OrdersList).Get(cacheKey, () => dbSrc.ToList());

            var count = list.Count();
            var lists = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var dtoList = Mapper.Map<List<GetOrdersListDto>>(lists);

            return new PagedResultDto<GetOrdersListDto>(count, dtoList);
        }
        public PagedResultDto<GetOrdersListDto> GetOrdersListForUser(GetOrdersInput input)
        {
            input.UserID = AbpSession.GetUserId();
            return GetOrdersList(input);
        }

        private string GenerateOrderNo(OrderType tradeType)
        {
            return UniqueNumber.GetUniqueNumber(tradeType.ToString());
        }

    }
}
