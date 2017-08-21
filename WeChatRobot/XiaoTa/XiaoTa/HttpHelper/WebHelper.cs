namespace HttpHelper
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    public class WebHelper
    {
        #region 访问服务器时的cookies
        /// <summary>
        /// 访问服务器时的cookies
        /// </summary>
        public static CookieContainer CookiesContainer;
        #endregion

        #region 向服务器发送get请求  返回服务器回复数据
        /// <summary>
        /// 向服务器发送get请求  返回服务器回复数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] SendGetRequest(string url, int timeOut = 50000)
        {
            Stream responseStream = null;
            HttpWebResponse response = null;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = timeOut;
                request.Method = "get";

                if (CookiesContainer == null)
                {
                    CookiesContainer = new CookieContainer();
                }

                request.CookieContainer = CookiesContainer; //启用cookie

                response = (HttpWebResponse)request.GetResponse();
                request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version11;
                responseStream = response.GetResponseStream();

                var count = (int)response.ContentLength;
                var offset = 0;
                var buf = new byte[count];
                while (count > 0) //读取返回数据
                {
                    if (responseStream == null)
                    {
                        continue;
                    }
                    var n = responseStream.Read(buf, offset, count);
                    if (n == 0)
                    {
                        break;
                    }
                    count -= n;
                    offset += n;
                }
                return buf;
            }
            // ReSharper disable once UnusedVariable
            catch (Exception)
            {
                return null;
            }
            finally
            {
                responseStream?.Close();
                response?.Close();
            }
        }
        #endregion

        #region 向服务器发送post请求 返回服务器回复数据
        /// <summary>
        /// 向服务器发送post请求 返回服务器回复数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public byte[] SendPostRequest(string url, string body)
        {
            try
            {
                var requestBody = Encoding.UTF8.GetBytes(body);

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "post";
                request.ContentLength = requestBody.Length;

                var requestStream = request.GetRequestStream();

                requestStream.Write(requestBody, 0, requestBody.Length);

                if (CookiesContainer == null)
                {
                    CookiesContainer = new CookieContainer();
                }
                request.CookieContainer = CookiesContainer;  //启用cookie

                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();

                var count = (int)response.ContentLength;
                var offset = 0;
                var buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    if (responseStream == null)
                    {
                        continue;
                    }
                    var n = responseStream.Read(buf, offset, count);
                    if (n == 0)
                    {
                        break;
                    }
                    count -= n;
                    offset += n;
                }
                return buf;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 获取指定cookie
        /// <summary>
        /// 获取指定cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Cookie GetCookie(string name)
        {
            var cookies = GetAllCookies(CookiesContainer);
            foreach (var c in cookies)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }
        #endregion

        #region 打开系统默认浏览器
        /// <summary>
        /// 打开系统默认浏览器
        /// </summary>
        /// <param name="url"></param>
        public static void OpenExplorer(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        #endregion

        #region （private）获取全部Cookie
        /// <summary>
        /// 获取全部Cookie
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        private static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            var lstCookies = new List<Cookie>();

            var table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (var pathList in table.Values)
            {
                var lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                {
                    foreach (Cookie c in colCookies)
                    {
                        lstCookies.Add(c);
                    }
                }
            }
            return lstCookies;
        }
        #endregion

    }
}
