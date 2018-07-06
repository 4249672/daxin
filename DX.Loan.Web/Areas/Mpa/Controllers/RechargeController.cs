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
using DX.Loan.Authorization.Users;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Customer)]
    public class RechargeController : LoanControllerBase
    {
        private readonly ITradeAppService _tradeAppService;
        private readonly IUserAppService _userAppService;

        public RechargeController(ITradeAppService tradeAppService, IUserAppService userAppService)
        {
            _tradeAppService = tradeAppService;
            _userAppService = userAppService;
        }
        
        // GET: Mpa/Recharge
        public ActionResult Index(TradeInput input)
        {
            var list = _tradeAppService.GetUserTradeRecordList(input);
            RechargeListViewModel listview = new RechargeListViewModel() { List = list };
            return View(listview);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Recharge_Create, AppPermissions.Pages_Administration_Recharge_Edit)]
        public async Task<PartialViewResult> CreateModal(int? id)
        {
            return PartialView("_CreateModal");
        }

        //public async Task<PartialViewResult> UsersModal(long id)
        //{
        //    var users = await _userAppService.GetUsers(new Authorization.Users.Dto.GetUsersInput() { });

        //    UsersListViewModel viewModel = new UsersListViewModel();
        //    viewModel.Users = users;

        //    return PartialView("_PermissionsModal", viewModel);
        //}

    }
}