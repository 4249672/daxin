using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan
{
    public interface INoticeCache : IEntityCache<NoticeCacheItem>
    {
    }

    public class NoticeCache : EntityCache<Notice, NoticeCacheItem>, INoticeCache, ISingletonDependency {

        public NoticeCache(ICacheManager cacheManager, IRepository<Notice> repository):base(cacheManager,repository) { }

    }


}
