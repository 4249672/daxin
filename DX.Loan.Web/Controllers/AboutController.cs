using System.Web.Mvc;

namespace DX.Loan.Web.Controllers
{
    public class AboutController : LoanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}