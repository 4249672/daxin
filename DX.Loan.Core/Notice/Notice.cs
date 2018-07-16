using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;


namespace DX.Loan
{
    [Table("Notice")]
    public class Notice: AuditedEntity<int>
    {
        [MaxLength(100)]
        public string Title { get; set; }

        //短标题
        [MaxLength(50)]
        public string ShortTitle { get; set; }

        //是否重要
        //public short Important { get; set; }

        //发布者
        [MaxLength(30)]
        public string Author { get; set; }

        //排序时，优先顺序
        public int Prior { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime? PublicDate { get; set; }

        //版本控制
        public byte[] RowVersion { get; set; }
    }
}
