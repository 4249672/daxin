using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace DX.Loan
{
    //关联 Order
    [Table("CustomerInfo")]
    public class CustomerInfo: CreationAuditedEntity<long>, IPassivable //ISoftDelete
    {
        //姓　名
        [Required]
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
        //[MaxLength(30)]
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
        
        //信息是否完整
        public int? IsComplete { get; set; }

        //交易次数，被售出的次数
        public int? TransTimes { get; set; }
        //此条价格
        public decimal? RecordCharge { get; set; }
        
        public bool IsActive { get; set; }
    }
}
