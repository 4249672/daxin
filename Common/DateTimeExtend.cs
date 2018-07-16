using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common
{
    public static class DateTimeExtend
    {

        public static int CompareByDate(this DateTime? d1, DateTime d2) {
            if (!d1.HasValue)
                return -1;
            return d1.Value.CompareByDate(d2);
        }

        public static int CompareByDate(this DateTime d1, DateTime d2)
        {
            DateTime tmpD1 = d1.Date;
            DateTime tmpD2 = d2.Date;
            return tmpD1.CompareTo(d2);
        }

        /// <summary>
        /// yyyymmdd
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string AsDateString(this DateTime d)
        {
            DateTime date = DateTime.Now;
            string tmp = "" + date.Year;
            tmp += (date.Month < 10 ? "0" : "") + date.Month;
            tmp += (date.Day < 10 ? "0" : "") + date.Day;
            return tmp;
        }

        /// <summary>
        /// 某种格式的日期字符串转换成另一种日期格式字符串
        /// </summary>
        /// <param name="dateStr"></param>
        /// <param name="ToStrFormat">转换之后的日期格式</param>
        /// <param name="dateTimeFormat">当前日期的格式</param>
        /// <param name="culturInfo">语言类型</param>
        /// <returns></returns>
        public static string AsDateFormat(this string dateStr, string ToStrFormat = "yyyy-MM-dd", string dateTimeFormat = "dd/MM/yyyy",string culturInfo = "zh-CN")
        {
            DateTime result;
            IFormatProvider formatPrvd = new CultureInfo(culturInfo);
            if (DateTime.TryParseExact(dateStr, dateTimeFormat, formatPrvd, DateTimeStyles.AllowInnerWhite, out result))
            {
                return result.ToString(ToStrFormat);
            }
            return "";
        }

        public static DateTime AsDateTime(this String s, DateTime defaultValue = new DateTime())
        {
            DateTime result;
            return DateTime.TryParse(s, out result) ? result : defaultValue;
        }

        public static DateTime? AsDateTimeOfNull(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            DateTime res;
            if (DateTime.TryParse(s, out res))
                return res;

            return null;
        }
    }
}
