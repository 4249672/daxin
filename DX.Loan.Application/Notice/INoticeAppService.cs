using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan
{
    public interface INoticeAppService : IApplicationService
    {

        PagedResultDto<NoticeDto> GetNotices(SearchNoticeInput input);

        void CreateOrUpdateNotice(CreateOrUpdateNoticeInput input);

        NoticeEditDto GetNoticeForEdit(NullableIdDto input);

        NoticeCacheItem GetNoticeForEditFromCache(NullableIdDto input);

        void DeleteNotice(EntityDto input);

        ListResultDto<NoticeDto> GetNoticesListForUser(int count);
    }
}
