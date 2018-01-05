using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Authorization;
using DX.Loan.Web.Controllers;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : LoanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}