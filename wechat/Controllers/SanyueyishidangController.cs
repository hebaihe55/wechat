using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class SanyueyishidangController : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Sanyueyishidang
        public ActionResult subinfo()
        {
            HttpCookie hc = Request.Cookies["wechat"];

            if (hc == null)
            {
                hc = new HttpCookie("wechat");
                hc.Value = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                hc.Expires = DateTime.Now.AddDays(365);
                Response.AppendCookie(hc);
            }

            string id = hc.Value;

            int  i = db.GGKs.Where(t => t.openid.Equals(id) && t.actname.Equals("三越暑假大抽奖")).Count();
            if (i >= 1)
            {
                return RedirectToAction("thank");
            }
            return View();
        }

        [HttpPost]
        public ActionResult add(Models.GGK ggk)
        {
            HttpCookie hc = Request.Cookies["wechat"];

            ggk.openid = hc.Value;
            ggk.actname = "三越暑假大抽奖";
            ggk.cctime = DateTime.Now;

            try
            {
                db.GGKs.Add(ggk);
                db.SaveChanges();
            }
            catch (Exception)
            {


                throw;
            }


            return   RedirectToAction("thank");
        }

        public ActionResult thank()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}