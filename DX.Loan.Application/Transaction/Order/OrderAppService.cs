using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DX.Loan.CustomerMaint;
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
        private ICustomerManager _customerManager;
        private readonly IRepository<DX.Loan.Order, long> _orderRepository;
        private readonly ICacheManager _cacheManager;


        public Task<bool> CreateOrder(CreateOrderInput input)
        {
            var customer = _customerManager.GetCustomer(input.CustomerId);
            if(customer == null)
                throw new UserFriendlyException("未找到对应客户信息,购买订单失败");

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

            order.OrderAmount = input.OrderAmount;
            order.OrderNo = "";
            order.Status = OrderType.YFK.ToString(); //已付款
            order.UserId = userId;





        }

        public GetOrderDto GetOrder(EntityDto<long> input)
        {
            throw new NotImplementedException();
        }

        public List<GetOrdersListDto> GetOrdersList(GetOrdersInput input)
        {
            throw new NotImplementedException();
        }
    }
}
