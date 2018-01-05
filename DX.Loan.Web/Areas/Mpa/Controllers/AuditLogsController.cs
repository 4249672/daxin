using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Authorization;
using DX.Loan.Web.Controllers;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : LoanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}