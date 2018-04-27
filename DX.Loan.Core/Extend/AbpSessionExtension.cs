using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Extend
{
    public static class AbpSessionExtension
    {
        private static string GetClaimValue(string claimType) {
            var claimPrincipal = DefaultPrincipalAccessor.Instance.Principal;
            var claim = claimPrincipal?.Claims.FirstOrDefault(m => m.Type == claimType);
            if (string.IsNullOrEmpty(claim?.Value))
                return null;
            return claim.Value;
        }

        public static long GetFinanceAccountId(this IAbpSession session) {
            var id = GetClaimValue(ClaimTypes.PrimarySid);
            long fid;
            if (!string.IsNullOrEmpty(id) && long.TryParse(id, out fid))
                return fid;
            else
                throw new ApplicationException("Get Finance Account Id is null");
        }
    }
}
