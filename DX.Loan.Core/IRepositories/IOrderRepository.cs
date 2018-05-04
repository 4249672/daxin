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

        IQueryable<Order> GetOrdersForUser(long userId, DateTime? startDate = null, DateTime? endDate = null);

        Order GetOneOrderForUser(long userId, long Id);

        IQueryable<Order> GetOrdersIncludingForUser(long userId, Expression<Func<Order, object>>[] propertySelector);

    }
}
