using Abp.AutoMapper;
using DX.Loan.Authorization.Users;
using DX.Loan.Authorization.Users.Dto;
using DX.Loan.Web.Areas.Mpa.Models.Common;

namespace DX.Loan.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}