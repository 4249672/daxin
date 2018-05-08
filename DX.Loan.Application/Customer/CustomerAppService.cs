using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX.Loan.Customer.Dto;
using Abp.Authorization;
using DX.Loan.Authorization;
using Abp.Configuration;
using DX.Loan.Configuration;
using DX.Loan.CustomerMaint;
using Common;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using AutoMapper;

namespace DX.Loan.Customer
{
    public class CustomerAppService: LoanAppServiceBase, ICustomerAppService
    {
        private IRepository<CustomerInfo,long> _customerRespository;
        private readonly ICustomerManager _customerManage;
        private readonly ICacheManager _cacheManager;

        public CustomerAppService(IRepository<CustomerInfo, long> customerRespository, ICustomerManager customerManage, ICacheManager cacheManager) {
            _customerRespository = customerRespository;
            _customerManage = customerManage;
            _cacheManager = cacheManager;
        }

        #region 给客户查看的

        public PagedResultDto<CustomerForUserPageDto> GetCustomersForUserByList(SearchCustomerForUserInput input) {
            
            List<CustomerInfo> cacheList = _customerManage.GetCacheCustomerForUserByList();

            var count = cacheList.Count();
            var lists = cacheList.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var dtoList = lists.MapTo<List<CustomerForUserPageDto>>();
            
            var userId = ","+AbpSession.GetUserId().ToString() + ",";
            Parallel.ForEach(dtoList, m => {
                var ids = "," + m.BuyUserIds;
                if (ids.IndexOf(userId) != -1)
                    m.ShowForUserStatus = CustomerStatus.C.ToString();
            });
            return new PagedResultDto<CustomerForUserPageDto>(count, dtoList);
        }
        
        //private List<CustomerForUserPageDto> GetCacheCustomerForUserByList() {

        //    var startDate = DateTime.Now.AddDays(AppConsts.AccessCustomerLimitDayRange).ToString("yyyy-MM-dd 00:00:00").AsDateTimeOfNull();
        //    var endDate = DateTime.Now.ToString("yyyy-MM-dd 23:59:59").AsDateTimeOfNull();
            
        //    CustomerSearchCondition condition = new CustomerSearchCondition() { CreationTimeFrom = startDate , CreationTimeTo = endDate };
            
        //    string cacheKey = "Global_CustomerDBList";
        //    var list = _cacheManager.GetCache<string, List<CustomerForUserPageDto>>(AppConsts.Cache_CustomerAppService_Method_CacheCustomerForUserByList)
        //        .Get(cacheKey, () =>_customerManage.GetCustomersList(condition).ToList().MapTo<List<CustomerForUserPageDto>>());
        //    return list;

        //}
        
        #endregion
        
        [AbpAuthorize(AppPermissions.Pages_Administration_Customer)]
        public ListResultDto<CustomerDto> GetCustomers(SearchCustomerInput input) {

            var list = _customerRespository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Name),m=>m.Name.Contains(input.Name))
                .WhereIf(input.minAge.HasValue,m=>m.Age>=input.minAge) //年龄
                .WhereIf(input.maxAge.HasValue, m => m.Age <= input.maxAge)
                .WhereIf(input.minScore.HasValue, m => m.SesameScore >= input.minScore)//芝麻分
                .WhereIf(input.maxScore.HasValue, m => m.SesameScore <= input.maxScore)
                .WhereIf(input.startDate.HasValue, m => m.ApplicationDate >= input.startDate) //申请时间
                .WhereIf(input.endDate.HasValue, m => m.ApplicationDate <= input.endDate)
                .OrderBy(m=>m.CreationTime).ToList();

            return new ListResultDto<CustomerDto>(list.MapTo<List<CustomerDto>>());
        }
        [AbpAuthorize(AppPermissions.Pages_Administration_Customer_Create)]
        protected void CreateCustomer(CreateOrUpdateCustomerInput input)
        {
            var entity = input.Customer.MapTo<CustomerInfo>();
            _customerRespository.Insert(entity);
        }
        [AbpAuthorize(AppPermissions.Pages_Administration_Customer_Edit)]
        protected void UpdateCustomer(CreateOrUpdateCustomerInput input) {
            var entity = _customerRespository.Get(input.Customer.Id.Value);
            entity.Name = input.Customer.Name;
            entity.Area = input.Customer.Area;
            entity.Age = input.Customer.Age;
            entity.IdCard = input.Customer.IdCard;
            entity.Interest = input.Customer.Interest;
            entity.DebitAmount = input.Customer.DebitAmount;
            entity.SesameScore = input.Customer.SesameScore;
            entity.CreditRating = input.Customer.CreditRating;
            entity.ApplicationDate = input.Customer.ApplicationDate;
            entity.Tel = input.Customer.Tel;
            entity.WeChat = input.Customer.WeChat;
            entity.QQ = input.Customer.QQ;
            entity.AppEquipment = input.Customer.AppEquipment;
            entity.Source = input.Customer.Source;
            entity.IsComplete = input.Customer.IsComplete;
            entity.RecordCharge = input.Customer.RecordCharge;

        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Customer_Create, AppPermissions.Pages_Administration_Customer_Edit)]
        public void CreateOrUpdateCustomer(CreateOrUpdateCustomerInput input)
        {
            if (input.Customer.Id.HasValue)
            {
                UpdateCustomer(input);
            }
            else
            {
                 CreateCustomer(input);
            }
        }
        
        [AbpAuthorize(AppPermissions.Pages_Administration_Customer_Delete)]
        public void DeleteCustomer(EntityDto input)
        {
            var entity = _customerRespository.Get(input.Id);
            _customerRespository.Delete(entity);
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Customer_Create, AppPermissions.Pages_Administration_Customer_Edit)]
        public CustomerEditDto GetCustomerForEdit(NullableIdDto input)
        {
            CustomerEditDto editDto;

            if (input.Id.HasValue) //Editing existing?
            {
                var customer = _customerRespository.Get(input.Id.Value);
                editDto = customer.MapTo<CustomerEditDto>();
            }
            else
            {
                editDto = new CustomerEditDto() { RecordCharge = Convert.ToDecimal(SettingManager.GetSettingValue(AppSettings.General.RecordChargeFee)) };
            }

            return editDto;
        }

    }
}
