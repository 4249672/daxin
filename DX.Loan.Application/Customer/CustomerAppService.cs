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

namespace DX.Loan.Customer
{
    public class CustomerAppService: LoanAppServiceBase, ICustomerAppService
    {
        private IRepository<CustomerInfo,long> _customerRespository;

        public CustomerAppService(IRepository<CustomerInfo, long> customerRespository) {
            _customerRespository = customerRespository;
        }

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

        public void CreateCustomer(CustomerCreateInput input)
        {
            var entity = input.MapTo<CustomerInfo>();
            _customerRespository.Insert(entity);
        }
        
    }
}
