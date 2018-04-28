using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Trade.Dto
{
    /// <summary>
    /// 仅仅给用户展示
    /// </summary>
    [AutoMapFrom(typeof(FinanceTradeDetail))]
    public class TradeDetailsForUserDto : IHasCreationTime
    {
        //public long UserId { get; set; }

        //交易流水号
        public string SerialNo { get; set; }

        //交易类型 1:充值,2:返现;3:提现 ; 4:消费
        public string TradeType { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
