using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections;

namespace wechat.Utils
{
   public class Utils
    {
        /// <summary>
        /// 时间戳转为时间
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }



        /// <summary>
        /// 时间转换为时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// sha1加密
        /// </summary>
        /// <param name="str_sha1_in"></param>
        /// <returns></returns>
        public static string SHA1_Hash(string str_sha1_in)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = UTF8Encoding.Default.GetBytes(str_sha1_in);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            string str_sha1_out = BitConverter.ToString(bytes_sha1_out);
            str_sha1_out = str_sha1_out.Replace("-", "").ToLower();
            return str_sha1_out;
        }


        /// <summary>
        /// 判断手机网关
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        public static string ISPCheck(string mobile)
        {
            ArrayList YD =new ArrayList() { "139","138","137","136","135","134","159","150","151","158","157","188","187","152","182","147" };

            ArrayList LT = new ArrayList() { "130","131","132","155","156","186","185","145","176" };

            ArrayList DX = new ArrayList() { "133","153", "181", "180","189" };

            mobile = mobile.Substring(0, 3);

            if (YD.Contains(mobile))
            {
                return "移动";
            }

            if (LT.Contains(mobile))
            {
                return "联通";
            }

            if (DX.Contains(mobile))
            {
                return "电信";
            }

            return "未知";

        }



    }
}
