using Abp.Domain.Repositories;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Trade
{
    public class TradeManager : ITradeManager
    {
        private IRepository<FinanceTradeDetail, long> financeTradeDetailRepository;
        public ILogger Logger { get; set; }

        public TradeManager(IRepository<FinanceTradeDetail, long> fRepository) {
            financeTradeDetailRepository = fRepository;
            Logger = NullLogger.Instance;
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
    }
}
