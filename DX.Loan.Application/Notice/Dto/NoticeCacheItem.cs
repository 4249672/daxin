using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan
{
    [AutoMapFrom(typeof(Notice))]
    public class NoticeCacheItem
    {
        public string Title { get; set; }
        
        public string ShortTitle { get; set; }
        
        public string Author { get; set; }

        //排序时，优先顺序
        public int Prior { get; set; }
        
        public string Content { get; set; }

        public DateTime? PublicDate { get; set; }


    }
}
