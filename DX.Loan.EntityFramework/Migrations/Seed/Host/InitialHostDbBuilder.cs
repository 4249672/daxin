using DX.Loan.EntityFramework;

namespace DX.Loan.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly LoanDbContext _context;

        public InitialHostDbBuilder(LoanDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
