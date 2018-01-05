using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DX.Loan.Authorization.Users.Dto;

namespace DX.Loan.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
