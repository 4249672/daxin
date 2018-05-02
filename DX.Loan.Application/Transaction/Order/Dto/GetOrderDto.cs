using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction.Order.Dto
{
    [AutoMapFrom(typeof(DX.Loan.Order))]
    public class GetOrderDto : EntityDto<long>, IHasCreationTime
    {
        public string OrderNo { get; set; }

        public string Status { get; set; }

        public decimal? OrderAmount { get; set; }

        public long UserId { get; set; }

        //------------------------------------------

        //姓　名
        public string Name { get; set; }
        
        //地　区
        public string Area { get; set; }
        //年　龄
        public int? Age { get; set; }
        //身份证
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
        public string Tel { get; set; }
        //微　信
        public string WeChat { get; set; }
        //Q　 Q
        public string QQ { get; set; }

        //申请设备
        public string AppEquipment { get; set; }
        //来源
        public string Source { get; set; }

        public DateTime CreationTime { get; set; }



    }
}
