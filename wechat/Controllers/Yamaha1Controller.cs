using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Yamaha1Controller : Controller
    {
        // GET: Yamaha1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult rule()
        {
            return View();
        }
        public ActionResult subinfo()
        {
            return View();
        }
        public ActionResult t1()
        {
            return View();
        }
        public ActionResult t2()
        {
            return View();
        }
        public ActionResult t3()
        {
            return View();
        }
        public ActionResult t4()
        {
            return View();
        }
        public ActionResult t5()
        {
            return View();
        }
        public ActionResult t6()
        {
            return View();
        }
        public ActionResult t7()
        {
            return View();
        }
        public ActionResult t8()
        {
            return View();
        }
        public ActionResult t9()
        {
            return View();
        }
        public ActionResult t10()
        {
            return View();
        }


        public string  addcode(string id)
        {
            string code = DateTime.Now.ToString("mssfff");
           string url = HttpUtility.HtmlDecode("http://www.cl10086.com/garden/interface/sendSMS.action?phone=" +id+"&user=vipshanghai&pass=cheerlong,,&content=您的验证码为"+code+"【雅马哈】");
         string aa=  Utils.HttpService.Get(url);
            return code;

        }

        public ActionResult thank()
        {
            Utils.WeHelper.appid = "wx52d041442fbddbec";
            Utils.WeHelper.secret = "5041fed711106842c0f84b75f84bacea";

            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "yamaha" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            
            Utils.WeHelper.url = Request.Url.ToString();
            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult timu()
        {
            return View();
        }
        public ActionResult guaguaka()
        {
            return View();
        }
        public ActionResult gethongbaosubinfo()
        {
            return View();
        }
        public ActionResult getawardsubinfo()
        {
            return View();
        }
        public ActionResult thanknobutton()
        {
            return View();
        }
    }
}