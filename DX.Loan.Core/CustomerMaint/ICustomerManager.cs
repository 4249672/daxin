using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.CustomerMaint
{
    public interface ICustomerManager
    {

        CustomerInfo GetCustomer(long Id);

        IQueryable<CustomerInfo> GetCustomersList(CustomerSearchCondition input);

        List<CustomerInfo> GetCacheCustomerForUserByList();
    }
}
