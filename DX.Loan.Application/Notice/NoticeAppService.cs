using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DX.Loan.Customer.Dto;
using Abp.Authorization;
using DX.Loan.Authorization;
using Abp.Configuration;
using DX.Loan.Configuration;
using DX.Loan.CustomerMaint;
using Common;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using AutoMapper;
using System.Linq.Dynamic;
using Abp.UI;
using Abp.Domain.Uow;

namespace DX.Loan
{
    
    public class NoticeAppService : LoanAppServiceBase , INoticeAppService
    {
        private IRepository<Notice, int> _noticeRespository;
        private readonly ICacheManager _cacheManager;
        private readonly INoticeCache _noticeCache;
        private readonly string _cacheAppName = "NoticeAppService_Cache";
        private readonly string _cacheNoticeListForUser = "NoticeAppService_GetNoticesListForUser";
        private IUnitOfWorkManager _unitOfWorkManager;

        public NoticeAppService(IRepository<Notice, int>  noticeRespository , ICacheManager cacheManager, INoticeCache noticeCache, IUnitOfWorkManager unitOfWorkManager) {
            _noticeRespository = noticeRespository;
            _cacheManager = cacheManager;
            _noticeCache = noticeCache;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Notice_Create, AppPermissions.Pages_Administration_Notice_Edit)]
        public void CreateOrUpdateNotice(CreateOrUpdateNoticeInput input)
        {
            if (!input.notice.Id.HasValue)
                CreateNotice(input);
            else
                UpdateNotice(input);
            _cacheManager.GetCache(_cacheAppName).RemoveAsync(_cacheNoticeListForUser); //清除给用户看的列表缓存
        }

        private void CreateNotice(CreateOrUpdateNoticeInput input)
        {
            Notice model = input.notice.MapTo<Notice>();
            _noticeRespository.Insert(model);
        }

        private void UpdateNotice(CreateOrUpdateNoticeInput input)
        {
            try {
                Notice model = input.notice.MapTo<Notice>();
                 _noticeRespository.Update(model);
                _unitOfWorkManager.Current.SaveChanges();
            } catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex) {
                throw new UserFriendlyException(L("UpdateByOther"));
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Administration_Notice_Delete)]
        public void DeleteNotice(EntityDto input)
        {
            _noticeRespository.DeleteAsync(input.Id);
        }

        //修改用的
        [AbpAuthorize(AppPermissions.Pages_Administration_Notice_Edit)]
        public NoticeEditDto GetNoticeForEdit(NullableIdDto input)
        {
            if (input.Id.HasValue)
            {
                var item = _noticeRespository.Get(input.Id.Value);
                return item.MapTo<NoticeEditDto>();
            }
            else
                return new NoticeEditDto();
        }
        
        [AbpAuthorize(AppPermissions.Pages_Administration_Notice)]
        public PagedResultDto<NoticeDto> GetNotices(SearchNoticeInput input)
        {
            var startDate = (input.StartDate??DateTime.Now).Date;
            var endDate = (input.EndDate ?? DateTime.Now).Date.AddDays(1);

            var q = _noticeRespository.GetAll().WhereIf(!string.IsNullOrEmpty(input.Title), m => m.Title.Contains(input.Title))
                .WhereIf(input.StartDate.HasValue, m => m.PublicDate.Value >= startDate)
                .WhereIf(input.EndDate.HasValue, m => m.PublicDate.Value < endDate);
            int count = q.Count();
            var list = q.ToList().MapTo<List<NoticeDto>>();
            return new PagedResultDto<NoticeDto>(count, list);
        }

        //--------------------

        //从缓存中取，通常是给客户看的
        public NoticeCacheItem GetNoticeForEditFromCache(NullableIdDto input)
        {
            if (input.Id.HasValue) {
                var item = _noticeCache.Get(input.Id.Value);
                return item;
            } 
            else
                return new NoticeCacheItem();
        }
        
        //专门给用户看的列表 , 默认显示6条记录
        public ListResultDto<NoticeDto> GetNoticesListForUser(int count = 6) {
            var q = _noticeRespository.GetAll().OrderBy("Prior desc , PublicDate desc").Take(count);
            var src = _cacheManager.GetCache<string, ListResultDto<NoticeDto>>(_cacheAppName).Get(_cacheNoticeListForUser, m => new ListResultDto<NoticeDto>(q.ToList().MapTo<List<NoticeDto>>()));
            return src;
        }
    }
}
