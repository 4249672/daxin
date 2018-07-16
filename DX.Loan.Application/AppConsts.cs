namespace DX.Loan
{
    /// <summary>
    /// Some consts used in the application.
    /// </summary>
    public class AppConsts
    {
        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 20;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;

        #region 交易记录 / CustomerInfo 的默认访问时长
        /// <summary>
        /// 默认可以访问几个月之前的交易记录
        /// </summary>
        public const int AccessTradeLimitMonthRange = -3;

        /// <summary>
        /// 默认可以访问几个月之前的Customser记录
        /// </summary>
        public const int AccessCustomerLimitMonthRange = -3;
        
        /// <summary>
        /// 一条Customer记录能卖的次数
        /// </summary>
        public const int RecordCanSaleTimes = 6;

        #endregion
        
        //缓存项的名称, 方便查找/设置缓存的时间
        //TradeAppService 的方法 GetUserChargeForUser
        public const string Cache_TradeAppService_Method_UserChargeForUser = "Cache_Method_TradeAppService_UserChargeForUser";

        //OrderAppService
        public const string Cache_OrderAppService_Method_OrdersList = "Cache_Order_OrdersList";

        public const string Cache_Time_5Min = "Cache_Time_5Min";
        public const string Cache_Time_10Min = "Cache_Time_10Min";
        public const string Cache_Time_15Min = "Cache_Time_15Min";
        public const string Cache_Time_30Min = "Cache_Time_30Min";


    }
}
