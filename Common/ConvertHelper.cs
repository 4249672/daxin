using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ConvertHelper
    {
        public static double AsDouble(this string s, out bool isSuccess)
        {
            double result;
            return (isSuccess = double.TryParse(s, out result)) ? result : 0;
        }

        public static Nullable<decimal> AsDecimalOfNull(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            decimal res;
            if (Decimal.TryParse(s, out res))
                return res;

            return null;
        }

        public static Int32 AsInt(this String s, int defaultValue = 0)
        {
            int result = defaultValue;
            return int.TryParse(s, out result) ? result : defaultValue;
        }

        public static long AsLong(this String s, long defaultValue = 0)
        {
            long result = defaultValue;
            return long.TryParse(s, out result) ? result : defaultValue;
        }
        public static Nullable<Int64> AsLongOfNull(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            long res;
            if (long.TryParse(s, out res))
                return res;
            return null;
        }

        public static Boolean? AsBoolOfNull(this String s, bool? defaultValue = null)
        {
            bool result;
            return Boolean.TryParse(s, out result) ? result : defaultValue;
        }

        public static Nullable<DateTime> AsDateTimeOfNull(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            DateTime res;
            if (DateTime.TryParse(s, out res))
                return res;

            return null;
        }

        /// <summary>
		/// 首字母转大写
		/// </summary>
		/// <param name="strChange"></param>
		/// <returns></returns>
		public static string AsChangeFirstLetterToUpper(this string strChange)
        {
            try
            {
                if (!string.IsNullOrEmpty(strChange))
                {
                    string tempFirst = strChange.Substring(0, 1);
                    string tempElse = strChange.Substring(1, strChange.Length - 1);
                    return (tempFirst.ToUpper() + tempElse.ToLower());
                }
                return string.Empty;
            }
            catch
            {
                return strChange;
            }
        }

    }
}
