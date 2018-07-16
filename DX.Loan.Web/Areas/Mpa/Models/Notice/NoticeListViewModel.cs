using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DX.Loan.Web.Areas.Mpa.Models.Notice
{
    public class NoticeListViewModel
    {
        public ListResultDto<NoticeViewModel> ListForUser { get; set; }

        public PagedResultDto<NoticeViewModel> ListForEdit { get; set; }

        public NoticeViewModel Model { get; set; }



    }
}