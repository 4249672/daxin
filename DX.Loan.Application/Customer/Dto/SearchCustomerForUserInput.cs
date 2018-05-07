using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using DX.Loan.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Customer.Dto
{
    //给客户看的
    public class SearchCustomerForUserInput : PagedAndSortedInputDto, IShouldNormalize, ICustomValidate
    {
        //[Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int? minAge { get; set; }

        [Range(1, 100)]
        public int? maxAge { get; set; }

        //芝麻分
        [Range(0, 1200)]
        public int? minScore { get; set; }

        [Range(0, 1200)]
        public int? maxScore { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (startDate.HasValue && endDate.HasValue && startDate.Value > endDate.Value)
                context.Results.Add(new ValidationResult("结束日期必须大于或等于开始日期"));
            
        }

        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
                this.Sorting = "CreationTime DESC";
            if (!startDate.HasValue)
                startDate = DateTime.Now;
            if (!endDate.HasValue)
                endDate = DateTime.Now.AddMonths(AppConsts.AccessCustomerLimitMonthRange);
        }

    }
}
