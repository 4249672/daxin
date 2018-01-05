using System.Web.Mvc;
using Abp.Auditing;

namespace DX.Loan.Web.Controllers
{
    public class ErrorController : LoanControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}