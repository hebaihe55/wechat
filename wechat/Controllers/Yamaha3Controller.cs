using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wechat.Models;

namespace wechat.Controllers
{
    public class Yamaha3Controller : Controller
    {
        WechatEntities7 db = new WechatEntities7();
        // GET: Yamaha3
        public ActionResult zong()
        {
            return View();
        }
        public ActionResult zhishiindex()
        {
            return View();
        }
        public ActionResult timu()
        {
            var ss = (from p in db.yamahaTimu orderby Guid.NewGuid() select p).Take(1).SingleOrDefault();
            ViewBag.t = ss.timu;
            ViewBag.a = ss.A;
            ViewBag.b = ss.B;
            ViewBag.c = ss.C;
            ViewBag.d = ss.D;
            ViewBag.e = ss.E;
            return View();
        }
        [HttpPost]
        public ActionResult timu(yamahainfo i)
        {   
            if (Request.Form["t1"] != null)
            {
                i.openid = "xiao";
                i.wtime = DateTime.Now;
                i.wenti = Request.Form["wenti"];
                i.daan = Request.Form["t1"];
                i.zqdaan = Request.Form["t2"];
                if (i.daan == i.zqdaan)
                {
                    i.shif = "true";
                }
                else
                {

                    i.shif = "false";
                }
                db.yamahainfo.Add(i);
                db.SaveChanges();
            }

           int ii= db.yamahainfo.Where(w => w.openid.Equals("xiao")).Count();
            if (ii >= 5)
            {
                return RedirectToAction("complete");
            }
            return RedirectToAction("timu");
        }
        public ActionResult complete()
        {
            var scores = (from s in db.yamahainfo where s.shif == "true" && s.openid == "xiao" select s).Count();
            ViewBag.num = scores;
            return View();
        }
        public ActionResult peiduigame()
        {
            return View();
        }
        public ActionResult peiduicucess()
        {
            return View();
        }
    }
}