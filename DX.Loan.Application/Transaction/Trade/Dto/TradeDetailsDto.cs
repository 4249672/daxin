using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Trade.Dto
{
    //[AutoMapFrom(typeof(FinanceTradeDetail))]
    public class TradeDetailsDto : CreationAuditedEntityDto<long>
    {
        public long UserId { get; set; }

        //交易流水号
        public string SerialNo { get; set; }

        //交易类型 1:充值,2:返现;3:提现 ; 4:消费
        public string TradeType { get; set; }

        public decimal Amount { get; set; }

        public string RemarkSubmit { get; set; }

        public string RemarkAudit { get; set; }

        //如果是客户购买产生的 , 则记录购买的订单编号
        public string RefNo { get; set; }
    }
}
