using Abp.Domain.Services;

namespace DX.Loan
{
    public abstract class LoanDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected LoanDomainServiceBase()
        {
            LocalizationSourceName = LoanConsts.LocalizationSourceName;
        }
    }
}
