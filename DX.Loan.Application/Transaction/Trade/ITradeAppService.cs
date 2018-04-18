using Abp.Application.Services.Dto;
using DX.Loan.Transaction.Trade.Dto;
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
        /// <param name="input"></param>
        /// <returns></returns>
        bool RechargeTrade(RechargeInput input);

        /// <summary>
        /// 扣费
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool DeductionTrade(RechargeInput input);
        
        
        /// <summary>
        /// 查询充值记录 (针对给用户查询)
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<TradeDetailsDto>> GetUserRechargeList(TradeForUserInput input);

        /// <summary>
        /// 查询用户的交易记录 （包括充值，扣费记录）
        /// </summary>
        /// <returns></returns>
        Task<PagedResultDto<TradeDetailsDto>> GetUserTradeRecord(TradeInput input);
        
    }
}
