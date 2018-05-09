using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Localization;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Authorization;
using DX.Loan.Localization;
using DX.Loan.Web.Areas.Mpa.Models.Languages;
using DX.Loan.Web.Controllers;
using DX.Loan.Customer;
using DX.Loan.Transaction;
using DX.Loan.Transaction.Trade.Dto;
using DX.Loan.Web.Areas.Mpa.Models.Trade;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Customer)]
    public class RechargeController : LoanControllerBase
    {
        private readonly ITradeAppService _tradeAppService;

        public RechargeController(ITradeAppService tradeAppService)
        {
            _tradeAppService = tradeAppService;
        }
        
        // GET: Mpa/Recharge
        public ActionResult Index(TradeInput input)
        {
            var list = _tradeAppService.GetUserTradeRecordList(input);
            RechargeListViewModel listview = new RechargeListViewModel() { List = list };
            return View(listview);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Customer_Create, AppPermissions.Pages_Administration_Customer_Edit)]
        public async Task<PartialViewResult> CreateModal(int? id)
        {
            return PartialView("_CreateModal");
        }
        
    }
}