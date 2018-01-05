using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Authorization.Permissions.Dto;

namespace DX.Loan.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}