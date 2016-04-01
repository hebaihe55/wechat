using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;


namespace wechat.Utils
{
    public class WeHelper
    {
        private static string access_token;
        private static int expires_in;


        private static string ticket;
        private static int texpires_in;
        


        public static string appid { get; set; }
        public static string secret { get; set; }
        public static string noncestr { get; set; }
        public static string timestamp { get; set; }
        public static string url { get; set; }
        public static string signature
        { get {
                string string1 = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", Ticket, noncestr, timestamp, url);

                return Utils.SHA1_Hash(string1);
            } }

        public static string Access_token
        {
            get
            {
                if (access_token != "" && (expires_in + 7000) < Utils.ConvertDateTimeInt(DateTime.Now))
                {
                    return access_token;
                }

                string strJson = client_credential();

                if (strJson.IndexOf("access_token") > 0)
                {
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);

                    access_token = jd["access_token"].ToString();
                    expires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    return access_token;
                }

                return "";
            }


        }

        public static string Ticket
        {
            get
            {
                if (ticket != "" && (texpires_in + 7000) < Utils.ConvertDateTimeInt(DateTime.Now))
                {
                    return ticket;
                }

                string strJson = getticket();

                if (strJson.IndexOf("ok") > 0)
                {
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);

                    ticket = jd["ticket"].ToString();
                    texpires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    return ticket;
                }

                return "";
            }

            
        }


        /// <summary>
        /// jsticket票据
        /// </summary>
        /// <returns></returns>
        private static string getticket()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token="+Access_token+"&type=jsapi";

            return HttpService.Get(url);
        }



        /// <summary>
        /// 得到微信票据
        /// </summary>
        /// <returns></returns>
        private static string client_credential()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;

            return HttpService.Get(url);
        }
    }



}
