using Abp.Application.Services;
using DX.Loan.Tenants.Dashboard.Dto;

namespace DX.Loan.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
