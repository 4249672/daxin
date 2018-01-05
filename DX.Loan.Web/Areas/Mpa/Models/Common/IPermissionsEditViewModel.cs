using System.Collections.Generic;
using DX.Loan.Authorization.Permissions.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}