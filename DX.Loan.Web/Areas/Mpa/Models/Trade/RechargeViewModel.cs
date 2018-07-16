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

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TradeType { get; set; }

        public List<ComboboxItemDto> Users { get; set; }

        public List<ComboboxItemDto> TradeTypeList { get; set; }
    }
}