using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Commonality
{
    public static class DataHelper
    {

        /// <summary>
        /// 对象转字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static T JsonToObject<T>(this string str)
        {
            var obj = JsonConvert.DeserializeObject<T>(str);
            return obj;
        }

        /// <summary>
        /// 字节流转字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(this byte[] bytes)
        {
            if (bytes != null)
            {
                return Encoding.UTF8.GetString(bytes);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取十位或者十三位的时间戳
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetTimeStamp(int length)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            var t = (DateTime.Now.Ticks - startTime.Ticks) / 10000;
            return length == 13 ? t.ToString() : t.ToString().Substring(0, 10);
        }

        /// <summary>
        /// 字符串取反
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Negation(this string str)
        {
            var rs = str.ToCharArray();
            var result = rs.Reverse().ToArray();
            return new string(result);
        }

        /// <summary>
        /// 获取N位长度的随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandom(int length)
        {
            var ranStr = string.Empty;
            var ran = new Random();
            for (var i = 0; i < length; i++)
            {
                ranStr += ran.Next(0, 10).ToString();
            }
            return ranStr;
        }

    }

}
