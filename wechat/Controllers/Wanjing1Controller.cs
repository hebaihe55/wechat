using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Wanjing1Controller : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Wanjing
        public ActionResult Index(string uid)
        {
            if (uid == null)
            {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (DateTime.Now > DateTime.Parse("2016-07-10 23:59:59"))
            {
                return RedirectToAction("activeend");
            }
            var q1 = db.Updatas.Where(w =>  w.activeName.Equals("丸井活动1"));

            if (q1.Count() >= 200)
            {
                return RedirectToAction("liuliangzsend");
            }
            var q= db.Updatas.Where(w => w.openid.Equals(uid) && w.activeName.Equals("丸井活动1"));

            if (q.Count() != 0)
            {
                return RedirectToAction("thank");
            }

            if (q.Count() >= 200)
            {
                return RedirectToAction("liuliangzsend");
            }


            System.Web.HttpContext.Current.Session["openid"] = uid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQ(Models.QuestionShanTian QST)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(QST.q1);
            sb.Append(";");
            sb.Append(QST.q2);
            sb.Append(";");
            sb.Append(QST.q3);
            sb.Append(";");
            sb.Append(QST.q4);
            sb.Append(";");
            sb.Append(QST.q5);
            sb.Append(";");
            sb.Append(QST.q6);
            sb.Append(";");
            sb.Append(QST.q7);
            sb.Append(";");
            sb.Append(QST.q8);
            sb.Append(";");

            Models.Question q = new Models.Question();

            q.openid= Session["openid"].ToString();
            q.actname = "丸井活动1";
            q.cctime = DateTime.Now;
            q.answer = sb.ToString();


            try
            {
                db.Question.Add(q);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                Utils.Log.Error("wangj",ex.Message);
            }




            return RedirectToAction("tijiao");
        }

        public ActionResult tijiao()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(Models.Updata ud)
        {
            ud.openid = Session["openid"].ToString();

            ud.cctime = DateTime.Now;

            ud.activeName = "丸井活动1";

            ud.ISP = Utils.Utils.ISPCheck(ud.mobile);

            ud.fee = 0;

            if (ud.ISP == "移动")
            {
                ud.fee = 150;
            }
            else if (ud.ISP == "联通")
            {
                ud.fee = 100;
            }
            else if (ud.ISP == "电信")
            {
                ud.fee = 100;
            }
            else
            {
                ud.fee = 0;
            }
            var q1 = db.Updatas.Where(w => w.activeName.Equals("丸井活动1"));

            if (q1.Count() >= 200)
            {
                return RedirectToAction("liuliangzsend");
            }
            int ii = 0;
            try
            {
                db.Updatas.Add(ud);
             ii=   db.SaveChanges();

                if (ii == 1)
                {
                    string url = "http://3g.qqwa.cn/api/SendMDataPakage_LZY.aspx?t=addorder&timestamp=" + Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();

                    String JsonStr = "{\"signature\":\"wanjing1\",\"token\":\"xinghe\",\"outid\":\"ql12354\",\"mobile\":\"" + ud.mobile + "\",\"amount\":" + ud.fee + "}";


                    Utils.HttpService.PostJson(url, JsonStr);
                }
            }
            catch (Exception ex)
            {

                Utils.Log.Error("WanJing1", ex.Message);
            }




            return RedirectToAction("thank");
        }


        public ActionResult thank()
        {
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.appid = "wxd715b812e63477d8";
            Utils.WeHelper.secret = "2b93c141c4952745e7552fce65365dbf";

            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "wanjing" + DateTime.Now.ToString("yyyyMMddhhmmssfff");




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult activeend()
        {
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.appid = "wxd715b812e63477d8";
            Utils.WeHelper.secret = "2b93c141c4952745e7552fce65365dbf";

            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "wanjing" + DateTime.Now.ToString("yyyyMMddhhmmssfff");




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult liuliangzsend()
        {
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.appid = "wxd715b812e63477d8";
            Utils.WeHelper.secret = "2b93c141c4952745e7552fce65365dbf";

            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "wanjing" + DateTime.Now.ToString("yyyyMMddhhmmssfff");




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }

        public ActionResult ercode()
        {
          
            return View();
        }
    }

}