using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX.Loan.Transaction
{
    public interface ITradeAppService
    {
        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        bool Recharge(long userId, decimal amount);

        /// <summary>
        /// 查询充值记录
        /// </summary>
        /// <returns></returns>
        List<FinanceTradeDetail> GetUserRechargeList();

        /// <summary>
        /// 查询用户的交易记录
        /// </summary>
        /// <returns></returns>
        List<FinanceTradeDetail> GetUserTradeRecord();
        
    }
}
