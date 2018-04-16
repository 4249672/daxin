using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace DX.Loan
{
    [Table("Notice")]
    public class Notice: AuditedEntity<int>
    {

        public string Title { get; set; }

        //短标题
        public string ShortTitle { get; set; }

        //排序时，优先顺序
        public int Prior { get; set; }

        public string Content { get; set; }

    }
}
