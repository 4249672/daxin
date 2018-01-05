using System.Web.Mvc;

namespace DX.Loan.Web.Controllers
{
    public class HomeController : LoanControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}