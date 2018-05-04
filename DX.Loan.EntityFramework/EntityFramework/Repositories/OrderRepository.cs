using Abp.EntityFramework;
using DX.Loan.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.EntityFramework.Repositories
{
    public class OrderRepository : LoanRepositoryBase<Order, long>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<LoanDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public Order GetOneOrderForUser(long userId,long Id)
        {
            var order = Get(Id);
            if (order.UserId == userId)
                return order;
            return null;
        }
        
        public IQueryable<Order> GetOrdersForUser(long userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return GetAll().Where(m=>m.UserId == userId);
        }

        public IQueryable<Order> GetOrdersIncludingForUser(long userId, Expression<Func<Order, object>>[] propertySelector)
        {
            return GetAllIncluding(propertySelector).Where(m => m.UserId == userId);
        }

    }
}
