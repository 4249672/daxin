using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan
{
    [AutoMap(typeof(Notice))]
    public class NoticeEditDto : AuditedEntityDto<int?>
    {
        //public new int? Id { get; set; }

        public string Title { get; set; }

        //短标题
        public string ShortTitle { get; set; }
        
        //发布者
        public string Author { get; set; }

        //排序时，优先顺序
        public int Prior { get; set; }

        public string Content { get; set; }

        public DateTime? PublicDate { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
