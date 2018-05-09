using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Trade
{
    public interface ITradeManager
    {
        //创建交易记录
        bool CreateTrade(FinanceTradeDetail entity);

        /// <summary>
        /// 创建交易记录 为订单服务
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="customerNo"></param>
        /// <returns></returns>
        Task<bool> CreateTradeForOrderAsync(decimal amount, string orderNo);

        //产生交易单号
        string GenerateTradeNo(TradeType tradeType);

        //获取某用户的折扣
        decimal GetDiscount(long financeAccountId);

    }
}
