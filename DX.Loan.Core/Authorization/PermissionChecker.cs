using Abp.Authorization;
using DX.Loan.Authorization.Roles;
using DX.Loan.Authorization.Users;
using DX.Loan.MultiTenancy;

namespace DX.Loan.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
