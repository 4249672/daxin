using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using DX.Loan.Authorization.Users;
using DX.Loan.MultiTenancy;

namespace DX.Loan.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
