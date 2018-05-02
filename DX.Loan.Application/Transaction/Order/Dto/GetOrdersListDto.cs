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
    public class GetOrdersListDto: EntityDto<long>,IHasCreationTime
    {

        public string OrderNo { get; set; }

        public string Status { get; set; }

        public decimal? OrderAmount { get; set; }

        public long UserId { get; set; }

        //------------------------------------------

        public string Name { get; set; }
        public string Area { get; set; }
        public string IdCard { get; set; }
        //预计贷款金额
        public decimal? DebitAmount { get; set; }
        //芝麻分
        public int? SesameScore { get; set; }
        //申请日期
        public DateTime? ApplicationDate { get; set; }
        //手　机
        public string Tel { get; set; }
        //申请设备
        public string AppEquipment { get; set; }
        //来源
        public string Source { get; set; }

        public DateTime CreationTime { get ; set ; }
    }
}
