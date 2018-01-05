using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Web.Areas.Mpa.Models.Common.Modals;
using DX.Loan.Web.Controllers;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : LoanControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}