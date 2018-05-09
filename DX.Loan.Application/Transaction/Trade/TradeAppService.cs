using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using DX.Loan.Trade;
using DX.Loan.Transaction.Trade.Dto;
using System.Linq.Dynamic;
using AutoMapper;

namespace DX.Loan.Transaction
{
    public class TradeAppService : LoanAppServiceBase , ITradeAppService
    {
        private ITradeManager _tradeManager;
        private readonly IRepository<FinanceAccount,long> _financeAccount;
        private readonly ICacheManager _cacheManager;
        private readonly IRepository<FinanceTradeDetail,long> _financeTradeDetail;

        public TradeAppService(ITradeManager tradeManager, IRepository<FinanceAccount, long> financeAccount, ICacheManager cacheManager, IRepository<FinanceTradeDetail, long> financeTradeDetail) {
            _tradeManager = tradeManager;
            _financeAccount = financeAccount;
            _cacheManager = cacheManager;
            _financeTradeDetail = financeTradeDetail;
        }


        /// <summary>
        /// 给某个用户充值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork]
        public bool RechargeTrade(RechargeInput input)
        {
            return OperTrade(input, TradeType.CZ);
        }
        /// <summary>
        /// 给某个用户扣费
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [UnitOfWork]
        public bool DeductionTrade(RechargeInput input)
        {
            if (input.Amount > 0)
                input.Amount = input.Amount * -1;
            return OperTrade(input, TradeType.KF);
        }
        
        private bool OperTrade(RechargeInput input , TradeType tradeTyppe) {
            var account = _financeAccount.FirstOrDefault(m => m.UserId == input.userId);
            if (account != null)
            {
                account.Blance = account.Blance + input.Amount;
                
                FinanceTradeDetail entity = new FinanceTradeDetail();
                entity.UserId = input.userId;
                entity.Amount = input.Amount;
                entity.FinanceAccountId = account.Id;
                entity.TradeType = TradeType.CZ.ToString();
                entity.SerialNo = _tradeManager.GenerateTradeNo(tradeTyppe);
                return _tradeManager.CreateTrade(entity);
            }
            return false;
        }

        //仅仅针对某个登录用户
        public PagedResultDto<TradeDetailsForUserDto> GetUserChargeForUserList(TradeForUserInput input)
        {
            long userId = AbpSession.GetUserId();
            var dbSrc = _financeTradeDetail.GetAll().WhereIf(input.StartDate.HasValue, m => m.CreationTime >= input.StartDate.Value)
                                                    .WhereIf(input.EndDate.HasValue, m => m.CreationTime <= input.EndDate.Value)
                                                    .WhereIf(input.TradeType.IsNullOrWhiteSpace(), m=>m.TradeType == input.TradeType)
                                                    .Where(m => m.UserId == userId)
                                                    .Select(m=>new TradeDetailsForUserDto { TradeType = m.TradeType, CreationTime=m.CreationTime,Amount=m.Amount,SerialNo=m.SerialNo})
                                                    .OrderBy(input.Sorting);

            string startDate = (input.StartDate ?? DateTime.MinValue).ToShortTimeString();
            string endDate = (input.EndDate ?? DateTime.MinValue).ToShortTimeString();
            var cacheKey = @"GetUserChargeForUserList_{userId.ToString()}_{startDate}_{endDate}_{input.TradeType}";

            var list = 
                _cacheManager.GetCache<string, List<TradeDetailsForUserDto>>(AppConsts.Cache_TradeAppService_Method_UserChargeForUser).Get(cacheKey, ()=> dbSrc.ToList());

            var count = list.Count();
            var lists = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            return new PagedResultDto<TradeDetailsForUserDto>(count, lists);
        }

        public PagedResultDto<TradeDetailsDto> GetUserTradeRecordList(TradeInput input)
        {
            var dbSrc = _financeTradeDetail.GetAll().Where(m => m.UserId == input.userID)
                                                    .WhereIf(input.StartDate.HasValue, m => m.CreationTime >= input.StartDate.Value)
                                                    .WhereIf(input.EndDate.HasValue, m => m.CreationTime <= input.EndDate.Value)
                                                    .WhereIf(input.TradeType.IsNullOrWhiteSpace(), m => m.TradeType == input.TradeType)
                                                    .OrderBy(input.Sorting);
            var count = dbSrc.Count();
            var lists = dbSrc.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            var dtoList = Mapper.Map<List<TradeDetailsDto>>(lists);
            return new PagedResultDto<TradeDetailsDto>(count, dtoList);
        }

        
    }
}
