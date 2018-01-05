using EntityFramework.DynamicFilters;
using DX.Loan.EntityFramework;

namespace DX.Loan.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly LoanDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(LoanDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
