using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class GuiTianController : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: GuiTian
        public ActionResult Index()
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

            var q=  db.QuestionGuiTians.Where(t => t.openid == id).ToList<Models.QuestionGuiTian>();
            if (q.Count() >= 1)
            {
                return RedirectToAction("Ok");
            }

            ViewBag.openid = id;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.QuestionGuiTian q)
        {
            
            if (q.q1 == 9 && q.q2 == 9 && q.q3 == 9 && q.q4 == 9 && q.q5 == 9)
            {
                q.cctime = DateTime.Now;
                db.QuestionGuiTians.Add(q);
                db.SaveChanges();
                return RedirectToAction("Ok");

            }
            else
            {
                return RedirectToAction("Err");
            }
           
        }

        public ActionResult Ok()
        {
            return View();
        }

        public ActionResult Err(string openid)
        {
            ViewBag.openid = openid;
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