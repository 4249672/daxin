using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Web.Controllers;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : LoanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}