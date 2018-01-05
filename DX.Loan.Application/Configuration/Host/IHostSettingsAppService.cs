using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Configuration.Host.Dto;

namespace DX.Loan.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
