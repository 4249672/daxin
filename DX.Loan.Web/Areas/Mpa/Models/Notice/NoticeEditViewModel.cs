using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DX.Loan.Web.Areas.Mpa.Models.Notice
{
    //编辑页用的
    [AutoMapFrom(typeof(NoticeEditDto))]
    public class NoticeEditViewModel : NoticeEditDto
    {
        public bool IsEditMode
        {
            get { return this.Id.HasValue; }
        }

        public NoticeEditViewModel(NoticeEditDto dto) {
            dto.MapTo(this);
        }


    }
}