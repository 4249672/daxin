using System.Threading;

namespace DX.Loan.Localization
{
    public static class CultureHelper
    {
        public static bool IsRtl
        {
            get { return Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft; }
        }
    }
}
