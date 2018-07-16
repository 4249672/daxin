using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DX.Loan.Web.Areas.Mpa.Models.Notice
{
    //列表页用的
    [AutoMapFrom(typeof(NoticeDto))]
    public class NoticeViewModel : NoticeDto
    {
        public NoticeViewModel(NoticeDto dto) {
            dto.MapTo(this);
        }
    }
}