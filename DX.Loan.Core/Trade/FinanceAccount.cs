﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace DX.Loan
{
    /// <summary>
    /// 用户的账户信息表, 记录用户的等级, 资金
    /// </summary>
    [Table("Finance_Account")]
    public class FinanceAccount: AuditedEntity<long>, IPassivable
    {
        //用户编号 外键
        [Required]
        public long UserId { get; set; }

        //预付款
        public decimal? Advance { get; set; }

        //冻结预付款
        public decimal? AdvanceForzen { get; set; }

        //可用余额
        public decimal? Blance { get; set; }

        //冻结余额
        public decimal? BlanceFrozen { get; set; }

        //用户级别
        [MaxLength(20)]
        public string Level { get; set; }

        //状态 (冻结,正常)
        //public string Status { get; set; }
        public bool IsActive { get; set; } 

    }
}
  