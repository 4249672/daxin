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
using DX.Loan.Web.Areas.Mpa.Models.Customer;

namespace DX.Loan.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Customer)]
    public class CustomerController : LoanControllerBase
    {

        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService) {
            _customerAppService = customerAppService;
        }


        public ActionResult Index(SearchCustomerInput input)
        {

            var list = _customerAppService.GetCustomers(input);

            CustomerListViewModel vmModel = new CustomerListViewModel() { List = list };

            return View(vmModel);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Customer_Create, AppPermissions.Pages_Administration_Customer_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = _customerAppService.GetCustomerForEdit(new NullableIdDto { Id = id });
            var viewModel = new CustomerViewModel(output);

            return  PartialView("_CreateOrEditModal",viewModel);
        }
    }
}