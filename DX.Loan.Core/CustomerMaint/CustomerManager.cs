using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.CustomerMaint
{
    public class CustomerManager : ICustomerManager, IDomainService, ITransientDependency
    {
        private IRepository<CustomerInfo, long> _customerRepository;
        public ILogger Logger { get; set; }

        public CustomerManager(IRepository<CustomerInfo, long> customerRepository) {
            _customerRepository = customerRepository;
            Logger = NullLogger.Instance;
        }

        public CustomerInfo GetCustomer(long Id)
        {
            var customer = _customerRepository.Get(Id);
            return customer;
        }

        public IQueryable<CustomerInfo> GetCustomersList(CustomerSearchCondition input)
        {
            var list = _customerRepository.GetAll()
                                        .WhereIf(input.IdCard.IsNullOrWhiteSpace(), m => m.IdCard == input.IdCard)
                                        .WhereIf(input.Name.IsNullOrWhiteSpace(), m => m.Name == input.Name)
                                        .WhereIf(input.AgeFrom.HasValue, m => m.Age >= input.AgeFrom)
                                        .WhereIf(input.AgeTo.HasValue, m => m.Age <= input.AgeTo)
                                        .WhereIf(input.Area.IsNullOrWhiteSpace(), m => m.Area.StartsWith(input.Area))
                                        .WhereIf(input.AppEquipment.IsNullOrWhiteSpace(), m => m.AppEquipment == input.AppEquipment)
                                        .WhereIf(input.SesameScoreFrom.HasValue, m => m.SesameScore >= input.SesameScoreFrom)
                                        .WhereIf(input.SesameScoreTo.HasValue, m => m.SesameScore <= input.SesameScoreTo)
                                        .WhereIf(input.Source.IsNullOrWhiteSpace(), m => m.Source == input.Source)
                                        .WhereIf(input.Tel.IsNullOrWhiteSpace(), m => m.Tel == input.Tel)
                                        .WhereIf(input.WeChat.IsNullOrWhiteSpace(), m => m.WeChat == input.WeChat)
                                        .WhereIf(input.TransTimes.HasValue, m => m.TransTimes <= input.TransTimes)
                                        .WhereIf(input.CreationTimeFrom.HasValue, m => m.CreationTime >= input.CreationTimeFrom)
                                        .WhereIf(input.CreationTimeTo.HasValue, m => m.CreationTime <= input.CreationTimeTo)
                                        ;
            return list;
        }
    }
}
