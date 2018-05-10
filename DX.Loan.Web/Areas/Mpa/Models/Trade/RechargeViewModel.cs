using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DX.Loan.Web.Areas.Mpa.Models.Trade
{
    public class RechargeViewModel
    {
        public long userId { get; set; }
        
        public decimal Amount { get; set; }

        public List<ComboboxItemDto> Users { get; set; }


    }
}