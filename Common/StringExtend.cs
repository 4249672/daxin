using System;

namespace Common
{
    public static class StringExtend
    {
        /// <summary>
        /// 隐藏身份证中间的位数 , 默认是隐藏年月日
        /// </summary>
        /// <param name="idCard"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string HideIdCard(this string idCard, int startIndex = 6, int length = 8)
        {
            if (string.IsNullOrWhiteSpace(idCard))
                return "";
            return idCard.Substring(0, startIndex) + "".PadLeft(length, '*') + idCard.Substring(startIndex + length);
        }



    }
}
