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
        public ActionResult Index()
        {
            //if(id==null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Utils.WeHelper.appid = "wxf6eae6d355bd7d37";
            Utils.WeHelper.secret = "74e796b3733c3bda70924782b046e7fa";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "qilin" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            ViewBag.WechatUserId = "abaaaaaaaaaaa";
            return View();
        }


        [HttpPost]
        public int add(Models.ImgActive au)
        {
            //Utils.WeHelper.appid = "wxf6eae6d355bd7d37";
            //Utils.WeHelper.secret = "74e796b3733c3bda70924782b046e7fa";
            //Utils.WeHelper.url = Request.Url.ToString();
            //Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            //Utils.WeHelper.noncestr = "qilin" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            //Utils.WeHelper.MEDIA_ID = au.mediaId;


            //au.imgUrl = Utils.WeHelper.GetMultimedia();

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
            return View();
        }
        public ActionResult shangchuan()
        {

            return View();
        }
    }
}