using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Configuration.Tenants.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}