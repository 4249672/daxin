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
using DX.Loan.SqlExecuter;
using System.Data.SqlClient;
using Abp.Collections.Extensions;
using Abp.UI;

namespace DX.Loan.Customer
{
    //给客户查看的
    class CustomerClientAppService : LoanAppServiceBase, ICustomerClientAppService
    {

        private IRepository<CustomerInfo, long> _customerRespository;
        private readonly ICustomerManager _customerManage;
        private readonly ICacheManager _cacheManager;

        public CustomerClientAppService(IRepository<CustomerInfo, long> customerRespository, ICustomerManager customerManage, ICacheManager cacheManager)
        {
            _customerRespository = customerRespository;
            _customerManage = customerManage;
            _cacheManager = cacheManager;
        }

        public PagedResultDto<CustomerForUserPageDto> GetCustomersForUserByList(SearchCustomerForUserInput input)
        {
            List<CustomerInfo> cacheList = _customerManage.GetCacheCustomerForUserByList();

            cacheList.WhereIf(input.startDate.HasValue, m => m.ApplicationDate >= input.startDate)
                     .WhereIf(input.endDate.HasValue, m => m.ApplicationDate <= input.endDate)
                     .WhereIf(!string.IsNullOrEmpty(input.Area), m => m.Area.StartsWith(input.Area))
                     .WhereIf(input.maxAge.HasValue, m => m.Age <= input.maxAge)
                     .WhereIf(input.minAge.HasValue, m => m.Age >= input.minAge)
                     .WhereIf(input.maxScore.HasValue, m => m.SesameScore <= input.maxScore)
                     .WhereIf(input.minScore.HasValue, m => m.SesameScore >= input.minScore);

            var count = cacheList.Count();
            var cList = cacheList.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            var dtoList = cList.MapTo<List<CustomerForUserPageDto>>();

            var userId = "," + AbpSession.GetUserId().ToString() + ",";
            Parallel.ForEach(dtoList, m => {
                var ids = "," + m.BuyUserIds;
                if (ids.IndexOf(userId) != -1)
                    m.ShowForUserStatus = CustomerStatus.C.ToString();
            });
            return new PagedResultDto<CustomerForUserPageDto>(count, dtoList);
        }

        public CustomerForUserPageDto GetOneCustomerDetail(EntityDto<long> dto) {
            var model = _customerManage.GetCacheCustomerForUserByList().FirstOrDefault(m=>m.Id == dto.Id);
            if (model == null)
                throw new UserFriendlyException("未找到此记录");
            return model.MapTo<CustomerForUserPageDto>();
        }


    }
}
