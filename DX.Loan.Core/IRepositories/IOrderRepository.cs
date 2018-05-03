using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.IRepositories
{
    public interface IOrderRepository : IRepository<Order,long>
    {

        IQueryable<Order> GetOrdersForUser(Expression<Func<Order, bool>> predicate);

        Order GetOneOrderForUser(long Id);

    }
}
