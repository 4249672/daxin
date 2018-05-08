namespace DX.Loan
{
    /// <summary>
    /// Some general constants for the application.
    /// </summary>
    public class LoanConsts
    {
        public const string LocalizationSourceName = "Loan";

        public const bool MultiTenancyEnabled = true;

        /// <summary>
        /// 默认可访问Customer记录天数 , 用于缓存
        /// </summary>
        public const int AccessCustomerLimitDayRange = -30;


        //CustomerAppService
        public const string Cache_CustomerAppService_Method_CacheCustomerForUserByList = "Cache_CustomerAppService_Method_CacheCustomerForUserByList";
    }

    public enum TradeType {
        /// <summary>
        /// 充值
        /// </summary>
        CZ,
        /// <summary>
        /// 提现
        /// </summary>
        TX,
        /// <summary>
        /// 消费 ,  用户购买时产生的消费
        /// </summary>
        XF,
        /// <summary>
        /// 返现
        /// </summary>
        FX,
        /// <summary>
        /// 扣费 ,  扣减用户余额
        /// </summary>
        KF
    }

    public enum OrderType {
        /// <summary>
        /// 已付款
        /// </summary>
        FK,
        /// <summary>
        /// 未付款
        /// </summary>
        WF,
        /// <summary>
        /// 抢购失败
        /// </summary>
        SB,
        /// <summary>
        /// 取消交易
        /// </summary>
        QX
    }

    public enum CustomerStatus {
        /// <summary>
        /// 可购买
        /// </summary>
        Y,
        /// <summary>
        /// 不可购
        /// </summary>
        N,
        /// <summary>
        ///  已购买
        /// </summary>
        C

    }


}