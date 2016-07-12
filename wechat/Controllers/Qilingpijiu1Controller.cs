using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Qilingpijiu1Controller : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Qilingpijiu1
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int ii = db.GGKs.Where(w => w.actname.Equals("麒麟啤酒青春bar到") && w.cctime.Day.Equals(DateTime.Now.Day)).Count();
            if (ii >= 200)
            {
                return RedirectToAction("hongbaolingwan");
            }


            Utils.WeHelper.appid = "wxf6eae6d355bd7d37";
            Utils.WeHelper.secret = "74e796b3733c3bda70924782b046e7fa";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "qilin" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            ViewBag.WechatUserId = id;
            System.Web.HttpContext.Current.Session["openid"] = id;
      
            return View();
        }


        [HttpPost]
        
        public int add(Models.ImgActive au)
        {
            Utils.WeHelper.appid = "wxf6eae6d355bd7d37";
            Utils.WeHelper.secret = "74e796b3733c3bda70924782b046e7fa";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "qilin" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            Utils.WeHelper.MEDIA_ID = au.img1;


            au.img1 = Utils.WeHelper.GetMultimedia();

            au.ctime = DateTime.Now;

            
            int i = 0;
            try
            {
                db.ImgActives.Add(au);
                i = db.SaveChanges();
            }
            catch (Exception ex)
            {
                i = -1;
                Utils.Log.Error("imgadd", ex.StackTrace);
            }
            return i;
        }


        [HttpPost]
        public ActionResult addGGK(Models.GGK ggk)
        {



            ggk.openid = Session["openid"].ToString();

            ggk.actname = "麒麟啤酒青春bar到";

            ggk.cctime = DateTime.Now;

           int ii= db.GGKs.Where(w => w.openid.Equals(ggk.openid)).Count();
            if (ii != 0)
            {
                return RedirectToAction("thank");
            }

            int i = 0;
            try
            {
                db.GGKs.Add(ggk);
                i = db.SaveChanges();
            }
            catch (Exception ex)
            {
                i = -1;
                Utils.Log.Error("imgadd", ex.StackTrace);
            }
            return RedirectToAction("thank");
        }



        public ActionResult hongbaolingwan()
        {
            return View();
        }
        public ActionResult thank()
        {
            return View();
        }
        public ActionResult submitinfo()
        {
          string   openid = Session["openid"].ToString();
            int ii = db.GGKs.Where(w => w.openid.Equals(openid)).Count();
            if (ii != 0)
            {
                return RedirectToAction("thank");
            }
            return View();
        }
        public ActionResult shangchuan()
        {

            return View();
        }
    }
}