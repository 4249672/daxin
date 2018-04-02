using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace DX.Loan
{
    [Table("Finance_Account")]
    public class Order: CreationAuditedEntity<long>
    {
        public string OrderNo { get; set; }

        // 1 已付款 , 2 未付款 , 3 抢购失败 , 4 取消交易
        public string Status { get; set; }

        //实际付款金额
        public decimal? OrderAmount { get; set; }

        //****************************下面属性来自 CustomerInfo , 因为CustomerInfo 有可能被删除
        //姓　名
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string CustomerNo { get; set; }

        //地　区
        [MaxLength(60)]
        public string Area { get; set; }
        //年　龄
        public int? Age { get; set; }
        //身份证
        [MaxLength(20)]
        public string IdCard { get; set; }

        //预支付的利息
        public decimal? Interest { get; set; }
        //预计贷款金额
        public decimal? DebitAmount { get; set; }
        //芝麻分
        public int? SesameScore { get; set; }
        //信用评级
        public int? CreditRating { get; set; }

        //申请日期
        public DateTime? ApplicationDate { get; set; }

        //手　机
        [MaxLength(40)]
        public string Tel { get; set; }
        //微　信
        [MaxLength(60)]
        public string WeChat { get; set; }
        //Q　 Q
        [MaxLength(30)]
        public string QQ { get; set; }

        //申请设备
        [MaxLength(30)]
        public string AppEquipment { get; set; }
        //来源
        [MaxLength(30)]
        public string Source { get; set; }



    }
}
