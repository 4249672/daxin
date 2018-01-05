using Abp.AutoMapper;
using DX.Loan.MultiTenancy;
using DX.Loan.MultiTenancy.Dto;
using DX.Loan.Web.Areas.Mpa.Models.Common;

namespace DX.Loan.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}