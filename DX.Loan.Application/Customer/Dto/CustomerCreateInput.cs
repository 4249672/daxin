using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace DX.Loan.Customer.Dto
{
    [AutoMapTo(typeof(CustomerInfo))]
    public class CustomerCreateInput
    {
        //姓　名
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
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
        [MaxLength(30)]
        public string CreditRating { get; set; }

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

        //交易次数，被售出的次数
        public int? TransTimes { get; set; }
        //此条价格
        public decimal? RecordCharge { get; set; }





    }
}
