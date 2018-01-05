using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Editions.Dto;

namespace DX.Loan.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}