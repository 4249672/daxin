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
        
        public Order GetOneOrderForUser(long Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetOrdersForUser(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
