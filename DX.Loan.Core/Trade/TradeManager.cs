using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Trade
{
    public class TradeManager : ITradeManager , IDomainService, ITransientDependency
    {
        private readonly IRepository<FinanceTradeDetail, long> financeTradeDetailRepository;
        private IAbpSession AbpSession { get; set; }
        public ILogger Logger { get; set; }

        public TradeManager(IRepository<FinanceTradeDetail, long> fRepository) {
            financeTradeDetailRepository = fRepository;
            Logger = NullLogger.Instance;
            AbpSession = NullAbpSession.Instance;
        }

        public async Task<bool> CreateTradeForOrderAsync(decimal amount,string orderNo) {

            try {
                FinanceTradeDetail entity = new FinanceTradeDetail();
                entity.Amount = amount;
                entity.FinanceAccountId = AbpSession.GetFinanceAccountId();
                entity.RefNo = orderNo;
                entity.SerialNo = GenerateTradeNo(TradeType.XF);
                entity.UserId = AbpSession.GetUserId();
                await financeTradeDetailRepository.InsertAsync(entity);
                return true;
            } catch (Exception ex) {
                Logger.Error(ex.Message);
                return false;
            }
        }


        public bool CreateTrade(FinanceTradeDetail entity)
        {
            try
            {
                financeTradeDetailRepository.Insert(entity);
                return true;
            }
            catch (Exception ex) {
                Logger.Error(ex.Message);
                return false;
            }
        }

        public string GenerateTradeNo(TradeType tradeType)
        {
            return UniqueNumber.GetUniqueNumber(tradeType.ToString());
        }

        public decimal GetDiscount(long userId)
        {
            return 1;
        }
        
    }
}
