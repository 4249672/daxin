using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Editions.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}