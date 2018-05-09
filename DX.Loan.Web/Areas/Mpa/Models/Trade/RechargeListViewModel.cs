using System.Collections.Generic;
using Abp.Application.Services.Dto;
using DX.Loan.Transaction.Trade.Dto;

namespace DX.Loan.Web.Areas.Mpa.Models.Trade
{
    public class RechargeListViewModel
    {
        public PagedResultDto<TradeDetailsDto> List { get; set; }
    }
}