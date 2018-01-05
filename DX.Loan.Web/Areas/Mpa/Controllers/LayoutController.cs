﻿using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using Abp.Web.Mvc.Authorization;
using DX.Loan.Sessions;
using DX.Loan.Web.Areas.Mpa.Models.Layout;
using DX.Loan.Web.Areas.Mpa.Startup;
using DX.Loan.Web.Controllers;
using DX.Loan.Web.Models.Layout;
using DX.Loan.Web.Session;
using HeaderViewModel = DX.Loan.Web.Areas.Mpa.Models.Layout.HeaderViewModel;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class LayoutController : LoanControllerBase
    {
        private readonly IPerRequestSessionCache _sessionCache;
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ILanguageManager _languageManager;

        public LayoutController(
            IPerRequestSessionCache sessionCache, 
            IUserNavigationManager userNavigationManager, 
            IMultiTenancyConfig multiTenancyConfig,
            ILanguageManager languageManager)
        {
            _sessionCache = sessionCache;
            _userNavigationManager = userNavigationManager;
            _multiTenancyConfig = multiTenancyConfig;
            _languageManager = languageManager;
        }

        [ChildActionOnly]
        public PartialViewResult Header()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = AsyncHelper.RunSync(() => _sessionCache.GetCurrentLoginInformationsAsync()),
                Languages = _languageManager.GetLanguages(),
                CurrentLanguage = _languageManager.CurrentLanguage,
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                IsImpersonatedLogin = AbpSession.ImpersonatorUserId.HasValue
            };

            return PartialView("_Header", headerModel);
        }

        [ChildActionOnly]
        public PartialViewResult Sidebar(string currentPageName = "")
        {
            var sidebarModel = new SidebarViewModel
            {
                Menu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync(MpaNavigationProvider.MenuName, AbpSession.ToUserIdentifier())),
                CurrentPageName = currentPageName
            };

            return PartialView("_Sidebar", sidebarModel);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = AsyncHelper.RunSync(() => _sessionCache.GetCurrentLoginInformationsAsync())
            };

            return PartialView("_Footer", footerModel);
        }

        [ChildActionOnly]
        public PartialViewResult ChatBar()
        {
            return PartialView("_ChatBar");
        }

        [ChildActionOnly]
        public PartialViewResult TenantCustomCss()
        {
            var sessionInfo = AsyncHelper.RunSync(() => _sessionCache.GetCurrentLoginInformationsAsync());

            return PartialView("_TenantCustomCss", new TenantCustomCssViewModel
            {
                CustomCssId = sessionInfo.Tenant?.CustomCssId
            });
        }
    }
}