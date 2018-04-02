using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace DX.Loan.Trade
{
    [Table("Finance_Trade_Detail")]
    public class FinanceTradeDetail : CreationAuditedEntity<long>
    {
        //账户资金表编号 外键
        public long FinanceAccountId { get; set; }

        //用户编号 外键
        public long UserId { get; set; }

        //交易流水号
        public string SerialNo { get; set; }

        //交易类型 1:充值,2:返现;3:提现 ， 4:消费
        public string TradeType { get; set; }

        //支付渠道 internal:内部支付、trade.alipay.native:支付宝、trade.weixin.jspay:微信公众号支付、trade.weixin.native:微信扫码支付、trade.bankpay.native:网银
        public string PayChannel { get; set; }

        //第三方渠道交易单号,交易单号建议加表示业务来源和业务类型的前缀,如wxpnrechg...表示微信公众号充值,wxmabuy...表示微信小程序购买,wapalipaybuy...表示手机端支付宝购买
        public string OutTradeNo { get; set; }

        //交易金额
        public decimal Amount { get; set; }

        //交易币种
        public string Currency { get; set; }

        //交易申请备注
        public string RemarkSubmit { get; set; }

        //交易审核备注
        public string RemarkAudit { get; set; }

        //交易参数 JSON格式
        public string TradeParams { get; set; }
        
    }
}
