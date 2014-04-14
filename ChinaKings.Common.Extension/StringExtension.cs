using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtension
    {
        #region 编码解码
        /// <summary>
        /// 将目标字符串Base64编码
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string ToBase64String(this string data, Encoding encoding)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            return Convert.ToBase64String(encoding.GetBytes(data));
        }
        /// <summary>
        /// 将目标字符串Base64编码（默认utf-8）
        /// </summary>
        /// <param name="data">字符串</param>
        /// <returns></returns>
        public static string ToBase64String(this string data)
        {
            return data.ToBase64String(Encoding.UTF8);
        }
        /// <summary>
        /// 将目标字符串Base64解码
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string FromBase64String(this string data, Encoding encoding)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            return encoding.GetString(Convert.FromBase64String(data));
        }
        /// <summary>
        /// 将目标字符串Base64解码（默认utf-8）
        /// </summary>
        /// <param name="data">字符串</param>
        /// <returns></returns>
        public static string FromBase64String(this string data)
        {
            return data.FromBase64String(Encoding.UTF8);
        }
        #endregion

        #region 转换
        /// <summary>
        /// 字符串转换为int
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="default_value">默认值</param>
        /// <returns></returns>
        public static int ToInt(this string data, int default_value = 0)
        {
            int ret;
            return int.TryParse(data, out ret) ? ret : default_value;
        }
        /// <summary>
        /// 字符串转换为decimal
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="default_value">默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string data, decimal default_value = 0)
        {
            decimal ret;
            return decimal.TryParse(data, out ret) ? ret : default_value;
        }
        /// <summary>
        /// 字符串转换为float
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="default_value">默认值</param>
        /// <returns></returns>
        public static float ToFloat(this string data, float default_value = 0)
        {
            float ret;
            return float.TryParse(data, out ret) ? ret : default_value;
        }
        /// <summary>
        /// 字符串转换为Boolean
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="default_value">默认值</param>
        /// <returns></returns>
        public static Boolean ToBoolean(this string data, Boolean default_value = false)
        {
            Boolean ret;
            return Boolean.TryParse(data, out ret) ? ret : default_value;
        }
        #endregion
    }
}
