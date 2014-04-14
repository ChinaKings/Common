using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChinaKings.Common.WebHelper
{
    public class HttpHelper
    {
        /// <summary>
        /// 向指定地址发送请求（默认值为POST）
        /// </summary>
        /// <param name="url">指定地址</param>
        /// <param name="dataString">数据字符串（格式为：p1=v1&p2=v2）</param>
        /// <param name="cookies">HttpCookieCollection</param>
        /// <param name="method">发送方式（默认为POST）</param>
        /// <param name="charSet">编码格式（默认为UTF-8）</param>
        /// <returns></returns>
        private static string Response(string url, string dataString, HttpCookieCollection cookies, string method = "POST", string charSet = "utf-8")
        {
            Encoding encoding = Encoding.GetEncoding(charSet);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded";
            request.AllowAutoRedirect = true;
            byte[] data = encoding.GetBytes(dataString);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, encoding, true))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        /// <summary>
        /// 向指定地址发送GET请求
        /// </summary>
        /// <param name="url">指定地址</param>
        /// <param name="dataString">数据字符串（格式为：p1=v1&p2=v2）</param>
        /// <param name="cookies">HttpCookieCollection</param>
        /// <param name="charSet">编码格式（默认为UTF-8）</param>
        /// <returns></returns>
        public static string Get(string url, string dataString, HttpCookieCollection cookies, string charSet = "utf-8")
        {
            return Response(url, dataString, cookies, "GET", charSet);
        }
        /// <summary>
        /// 向指定地址发送GET请求
        /// </summary>
        /// <param name="url">指定地址</param>
        /// <param name="dataString">数据字符串（格式为：p1=v1&p2=v2）</param>
        /// <param name="charSet">编码格式（默认为UTF-8）</param>
        /// <returns></returns>
        public static string Get(string url, string dataString, string charSet = "utf-8")
        {
            return Get(url, dataString, null, charSet);
        }
        /// <summary>
        /// 向指定地址发送POST请求
        /// </summary>
        /// <param name="url">指定地址</param>
        /// <param name="dataString">数据字符串（格式为：p1=v1&p2=v2）</param>
        /// <param name="cookies">HttpCookieCollection</param>
        /// <param name="charSet">编码格式（默认为UTF-8）</param>
        /// <returns></returns>
        public static string Post(string url, string dataString, HttpCookieCollection cookies, string charSet = "utf-8")
        {
            return Response(url, dataString, cookies, "POST", charSet);
        }
        /// <summary>
        /// 向指定地址发送POST请求
        /// </summary>
        /// <param name="url">指定地址</param>
        /// <param name="dataString">数据字符串（格式为：p1=v1&p2=v2）</param>
        /// <param name="charSet">编码格式（默认为UTF-8）</param>
        /// <returns></returns>
        public static string Post(string url, string dataString, string charSet = "utf-8")
        {
            return Post(url, dataString, null, charSet);
        }
    }
}
