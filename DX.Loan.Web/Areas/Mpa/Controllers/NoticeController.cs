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
using DX.Loan.Web.Areas.Mpa.Models.Notice;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Notice)]
    public class NoticeController : LoanControllerBase
    {
        private readonly INoticeAppService _noticeAppService;

        public NoticeController(INoticeAppService noticeAppService)
        {
            _noticeAppService = noticeAppService;
        }

        // GET: Mpa/Notice
        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Notice_Create, AppPermissions.Pages_Administration_Notice_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = _noticeAppService.GetNoticeForEdit(new NullableIdDto { Id = id });
            if (!id.HasValue) {
                output.PublicDate = DateTime.Now;
                output.Prior = 0;
                output.Author = "管理员";
            }
            var viewModel = new NoticeEditViewModel(output);
            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}