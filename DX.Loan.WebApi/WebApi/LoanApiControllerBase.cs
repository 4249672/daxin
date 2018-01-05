using Abp.WebApi.Controllers;

namespace DX.Loan.WebApi
{
    public abstract class LoanApiControllerBase : AbpApiController
    {
        protected LoanApiControllerBase()
        {
            LocalizationSourceName = LoanConsts.LocalizationSourceName;
        }
    }
}