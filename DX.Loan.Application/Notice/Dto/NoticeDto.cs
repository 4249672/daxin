using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace DX.Loan
{
    [AutoMapFrom(typeof(Notice))]
    public class NoticeDto : AuditedEntityDto<int>
    {
        public string Title { get; set; }

        //短标题
        public string ShortTitle { get; set; }

        //发布者
        public string Author { get; set; }

        //排序时，优先顺序
        public int Prior { get; set; }
        
        //public string Content { get; set; }

        public DateTime? PublicDate { get; set; }
    }
}
