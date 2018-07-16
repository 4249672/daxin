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
using DX.Loan.Authorization.Users.Dto;
using System.Collections.Generic;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Recharge)]
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
        public async Task<ActionResult> Index(TradeInput input)
        {
            RechargeViewModel model = new RechargeViewModel();
            model.Users = await GetUserList();
            model.TradeTypeList = GetTradeType();
            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Recharge_Create)]
        public async Task<PartialViewResult> CreateModal(int? id)
        {
            RechargeViewModel model = new RechargeViewModel();
            
            var list = await GetUserList();
            model.Users = list;
            model.TradeTypeList = GetTradeType();

            return PartialView("_CreateModal",model);
        }

        private async Task<List<ComboboxItemDto>> GetUserList() {
            var input = new GetUsersInput();
            var list = await _userAppService.GetUsers(input);
            var rlist = list.Items.Select(m => new ComboboxItemDto() { DisplayText = m.UserName, Value = m.Id.ToString() }).ToList();
            rlist.Insert(0, new ComboboxItemDto("", ""));
            return rlist;
        }

        private List<ComboboxItemDto> GetTradeType() {
            return new List<ComboboxItemDto>() { new ComboboxItemDto() {  DisplayText="",Value= "" },
                                                new ComboboxItemDto() { DisplayText = "充值", Value = "CZ" },
                                                new ComboboxItemDto() {  DisplayText="扣款",Value= "KF" }
                                               };
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