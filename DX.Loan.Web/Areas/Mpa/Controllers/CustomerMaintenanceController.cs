﻿using System;
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

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    //仅用户界面的操作

    //[AbpMvcAuthorize(AppPermissions.Pages_Administration_CustomerMaint)]
    public class CustomerMaintenanceController : LoanControllerBase
    {
        
        public ActionResult Index()
        {
            return View();
        }
        

    }
}