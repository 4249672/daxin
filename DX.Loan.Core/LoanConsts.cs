using System.ComponentModel;

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
        [Description("充值")]
        CZ,
        /// <summary>
        /// 提现
        /// </summary>
        [Description("提现")]
        TX,
        /// <summary>
        /// 消费 ,  用户购买时产生的消费
        /// </summary>
        [Description("消费")]
        XF,
        /// <summary>
        /// 返现
        /// </summary>
        [Description("返现")]
        FX,
        /// <summary>
        /// 扣费 ,  扣减用户余额
        /// </summary>
        [Description("扣费")]
        KF
    }

    public enum OrderType {
        /// <summary>
        /// 已付款
        /// </summary>
        [Description("已付款")]
        FK,
        /// <summary>
        /// 未付款
        /// </summary>
        [Description("未付款")]
        WF,
        /// <summary>
        /// 抢购失败
        /// </summary>
        [Description("抢购失败")]
        SB,
        /// <summary>
        /// 取消交易
        /// </summary>
        [Description("取消交易")]
        QX
    }

    public enum CustomerStatus {
        /// <summary>
        /// 可购买
        /// </summary>
        [Description("可购买")]
        Y,
        /// <summary>
        /// 不可购
        /// </summary>
        [Description("不可购")]
        N,
        /// <summary>
        ///  已购买
        /// </summary>
        [Description("已购买")]
        C

    }


}