using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DX.Loan.Authorization.Permissions.Dto;

namespace DX.Loan.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
