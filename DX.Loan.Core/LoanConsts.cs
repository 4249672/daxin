namespace DX.Loan
{
    /// <summary>
    /// Some general constants for the application.
    /// </summary>
    public class LoanConsts
    {
        public const string LocalizationSourceName = "Loan";

        public const bool MultiTenancyEnabled = true;

        

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


}