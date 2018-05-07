using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Customer.Dto
{
    /// <summary>
    /// 显示给用户的列表
    /// </summary>
    public class CustomerForUserPageDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        //public string CustomerNo { get; set; }

        public string Area { get; set; }

        public int? Age { get; set; }
        //身份证
        public string IdCard { get; set; }
        //利　息
        public decimal? Interest { get; set; }

        public decimal? DebitAmount { get; set; }
        //芝麻分
        public int? SesameScore { get; set; }

        public int? CreditRating { get; set; }

        public DateTime? ApplicationDate { get; set; }

        //public string Tel { get; set; }

        //微　信
        //public string WeChat { get; set; }
        //Q　 Q
        //public string QQ { get; set; }
        //申请设备
        public string AppEquipment { get; set; }
        //来源
        public string Source { get; set; }

        //交易次数，被售出的次数
        //public int? TransTimes { get; set; }

        // 显示给用户的状态 : 可购买 / 不可购 / 已购买
        public string ShowForUserStatus { get; set; }

    }
}
