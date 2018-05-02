using Abp.Runtime.Validation;
using DX.Loan.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order.Dto
{
    public class GetOrdersInput : PagedAndSortedInputDto, IShouldNormalize, ICustomValidate
    {

        public long userID { get; set; }

        //订单生成的日期
        public DateTime? OrderStartDate { get; set; }

        public DateTime? OrderEndDate { get; set; }
        
        public string OrderNo { get; set; }

        //订单状态
        public string Status { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (OrderStartDate.HasValue && OrderEndDate.HasValue && OrderStartDate.Value > OrderEndDate)
                context.Results.Add(new ValidationResult("结束日期必须大于或等于开始日期"));
        }

        public void Normalize()
        {
            this.Sorting = "CreationTime DESC";
        }



    }
}
