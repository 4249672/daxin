using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using DX.Loan.Dto;
using System;

namespace DX.Loan.Transaction.Trade.Dto
{
    public class TradeForUserInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public void Normalize()
        {
            this.Sorting = "CreationTime";
        }
    }
}
