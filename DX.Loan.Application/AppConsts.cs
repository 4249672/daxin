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
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;

        /// <summary>
        /// 默认可以访问几个月之前的交易记录
        /// </summary>
        public const int AccessDateRange = -3;

        //缓存项的名称, 方便查找/设置缓存的时间
        //TradeAppService 的方法 GetUserChargeForUser
        public const string Cache_TradeAppService_Method_UserChargeForUser = "Cache_Method_TradeAppService_UserChargeForUser";

        //OrderAppService
        public const string Cache_OrderAppService_Method_OrdersList = "Cache_Order_OrdersList";



    }
}
