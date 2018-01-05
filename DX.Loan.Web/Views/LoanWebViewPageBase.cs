using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;

namespace DX.Loan.Web.Views
{
    public abstract class LoanWebViewPageBase : LoanWebViewPageBase<dynamic>
    {
       
    }

    public abstract class LoanWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected LoanWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = LoanConsts.LocalizationSourceName;
        }
    }
}