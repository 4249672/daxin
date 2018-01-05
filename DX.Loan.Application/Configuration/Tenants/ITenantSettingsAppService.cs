using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Configuration.Tenants.Dto;

namespace DX.Loan.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
