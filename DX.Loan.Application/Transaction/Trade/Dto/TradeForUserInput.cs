using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using DX.Loan.Dto;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DX.Loan.Transaction.Trade.Dto
{
    public class TradeForUserInput : PagedAndSortedInputDto, IShouldNormalize , ICustomValidate
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //public long? UserId { get; set; }

        public string TradeType { get; set; }
        
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (StartDate.HasValue && EndDate.HasValue && StartDate.Value > EndDate.Value)
                context.Results.Add(new ValidationResult("结束日期必须大于或等于开始日期"));
        }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
                this.Sorting = "CreationTime DESC";
            if (!StartDate.HasValue)
                StartDate = DateTime.Now.AddMonths(AppConsts.AccessTradeLimitMonthRange);
            if (!EndDate.HasValue)
                EndDate = DateTime.Now;
        }
    }
}
