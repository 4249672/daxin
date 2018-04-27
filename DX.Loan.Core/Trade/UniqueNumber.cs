using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DX.Loan.Trade
{
    public class UniqueNumber
    {
        private static long num = 0;//流水号
        private static object lockObj = new object();//锁

        private static long GenerateUniqueNumber()
        {
            Interlocked.Increment(ref num);
            num = (num == 100000 ? 1 : num); //如果大于10W则从零开始，由于一台服务器一秒内不太可能有10W并发，所以yymmddhhmmss+num是唯一号。yymmddhhmmss+num+SystemNo针对多台服务器也是唯一号。
            return num;
        }

        /// <summary>
        /// 产生编号
        /// </summary>
        /// <param name="TradeType">用于区分交易类别</param>
        /// <param name="SystemNo">系统号,针对不同服务器</param>
        /// <returns></returns>
        public static string GetUniqueNumber(string TradeType, string SystemNo = "")
        {
            lock (lockObj)// 要使静态变量多并发下同步，需要两次加锁。
            {
                string time = DateTime.Now.ToString("yyMMddHHmmss");//12位;
                return TradeType + SystemNo + long.Parse(time + GenerateUniqueNumber().ToString().PadLeft(5, '0'));//19位
            }
        }
    }
}
