using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using DX.Loan.Authorization.Roles;
using DX.Loan.Authorization.Users;
using DX.Loan.Chat;
using DX.Loan.Friendships;
using DX.Loan.MultiTenancy;
using DX.Loan.Storage;

namespace DX.Loan.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */

    public class LoanDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<CustomerInfo> CustomerInfos { get; set; }

        public virtual IDbSet<FinanceAccount> FinanceAccount { get; set; }
        public virtual IDbSet<FinanceTradeDetail> FinanceTradeDetail { get; set; }
        public virtual IDbSet<Order> Order { get; set; }



        public LoanDbContext()
            : base("Default")
        {
            
        }

        public LoanDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public LoanDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public LoanDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Ignore(a => a.Name);
            modelBuilder.Entity<User>().Ignore(a => a.Surname);
            modelBuilder.Entity<User>().Property(a => a.EmailAddress).IsOptional();
        }

    }
}
