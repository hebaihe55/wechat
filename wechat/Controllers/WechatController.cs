using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace wechat.Controllers
{
    public class WechatController : Controller
    {
        // GET: Wechat
        public ActionResult Index()
        {
            return View();
        }
        public string Api(string echostr)
        {
            if (echostr == "")
            {
                return "success";

            }
            return echostr;
        }

        [HttpPost]
        public void Api()
        {

            Stream st = Request.InputStream;

            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8"));

            String xmlStr = sr.ReadToEnd();

            Utils.Log.Info("apire", xmlStr);

            Utils.WxPayData wpd = new Utils.WxPayData();

            wpd.FromXml(xmlStr);


            DoWithReceive(wpd);






        }

        private void DoWithReceive(Utils.WxPayData WPD)
        {
            switch (WPD.GetValue("MsgType").ToString())
            {
                case "event":
                    DowithEvent(WPD);
                    break;
                case "text":
                    DowithText(WPD);
                    break;
                default:
                    Response.Write("");
                    Response.End();
                    break;

            }
        }

    
        private Utils.WxPayData redata = new Utils.WxPayData();

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="WPD"></param>
        private void DowithEvent(Utils.WxPayData WPD)
        {
            if (WPD.GetValue("ToUserName").ToString() == "gh_8e3ff9971691")
            {
                if (WPD.GetValue("Event").ToString() == "subscribe")
                {
                    string rexml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>20140814</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles><item><Title><![CDATA[明治巧克力拍照赢大奖!]]></Title> <Description><![CDATA[点击进入详情页面]]></Description><PicUrl><![CDATA[http://mvc.cjoy.cn/Content/Mingzhi1/image/fengmian1.jpg]]></PicUrl><Url><![CDATA[http://mvc.cjoy.cn/meiji1/index]]></Url></item></Articles></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());
                    Response.Write(rexml);
                    Response.End();
                }
                else
                {
                    Response.Write("");
                    Response.End();
                }
            }
        }
        //处理文本
        private void DowithText(Utils.WxPayData WPD)
        {
            if (WPD.GetValue("ToUserName").ToString() == "gh_8e3ff9971691")
            {

                if (WPD.GetValue("Content").ToString() == "分享")
                {
                    string rexml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>20140814</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles><item><Title><![CDATA[明治巧克力拍照赢大奖!]]></Title> <Description><![CDATA[点击进入详情页面]]></Description><PicUrl><![CDATA[http://mvc.cjoy.cn/Content/Mingzhi1/image/fengmian1.jpg]]></PicUrl><Url><![CDATA[http://mvc.cjoy.cn/meiji1/index]]></Url></item></Articles></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());
                    Response.Write(rexml);
                    Response.End();
                }
                else
                {
                    Response.Write("");
                    Response.End();
                }
            }

        }

    }
}