using System.Threading.Tasks;
using Abp.Configuration;

namespace DX.Loan.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
