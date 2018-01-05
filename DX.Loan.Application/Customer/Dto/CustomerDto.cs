using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace DX.Loan.Customer
{
    [AutoMapFrom(typeof(CustomerInfo))]
    public class CustomerDto: CreationAuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string Area { get; set; }

        public int? Age { get; set; }
        //身份证
        public string IdCard { get; set; }
        //利　息
        public decimal? Interest { get; set; }

        public decimal? DebitAmount { get; set; }
        //芝麻分
        public int? SesameScore { get; set; }

        public string CreditRating { get; set; }

        public DateTime? ApplicationDate { get; set; }

        public string Tel { get; set; }

        //微　信
        public string WeChat { get; set; }
        //Q　 Q
        public string QQ { get; set; }
        //申请设备
        public string AppEquipment { get; set; }
        //来源
        public string Source { get; set; }

        //交易次数，被售出的次数
        public int? TransTimes { get; set; }
        //此条价格
        public decimal? RecordCharge { get; set; }


    }
}
