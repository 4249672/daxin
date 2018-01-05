using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Sessions.Dto;

namespace DX.Loan.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
