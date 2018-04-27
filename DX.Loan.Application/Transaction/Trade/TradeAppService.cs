using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DX.Loan.Extend;
using DX.Loan.Trade;
using DX.Loan.Transaction.Trade.Dto;

namespace DX.Loan.Transaction
{
    public class TradeAppService : LoanAppServiceBase , ITradeAppService
    {
        private ITradeManager _tradeManager;
        private IRepository<FinanceAccount,long> _financeAccount;

        public TradeAppService(ITradeManager tradeManager, IRepository<FinanceAccount, long> financeAccount) {
            _tradeManager = tradeManager;
            _financeAccount = financeAccount;
        }


        /// <summary>
        /// 给某个用户充值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool RechargeTrade(RechargeInput input)
        {
            return OperTrade(input, TradeType.CZ);
        }
        /// <summary>
        /// 给某个用户扣费
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool DeductionTrade(RechargeInput input)
        {
            return OperTrade(input, TradeType.KF);
        }
        
        private bool OperTrade(RechargeInput input , TradeType tradeTyppe) {
            var account = _financeAccount.FirstOrDefault(m => m.UserId == input.userId);
            if (account != null)
            {
                FinanceTradeDetail entity = new FinanceTradeDetail();
                entity.UserId = input.userId;
                entity.Amount = input.Amount ?? 0;
                entity.FinanceAccountId = account.Id;
                entity.TradeType = TradeType.CZ.ToString();
                entity.SerialNo = _tradeManager.GenerateTradeNo(tradeTyppe);
                return _tradeManager.CreateTrade(entity);
            }
            return false;
        }


        public Task<PagedResultDto<TradeDetailsDto>> GetUserChargeForUserList(TradeForUserInput input)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<TradeDetailsDto>> GetUserTradeRecordList(TradeInput input)
        {
            throw new NotImplementedException();
        }

        
    }
}
