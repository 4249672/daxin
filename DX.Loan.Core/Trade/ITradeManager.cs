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
        bool CreateTrade(FinanceTradeDetail input);

    }
}
