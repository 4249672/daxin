using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order
{
    public interface IOrderAppService
    {

        List<DX.Loan.Order> GetOrders();

        bool CreateOrder();

    }
}
