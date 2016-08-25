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
        WechatEntities6 db = new WechatEntities6();
        // GET: Yamaha3
        public ActionResult zong()
        {

            return View();
        }
        public ActionResult zhishiindex()
        {
           
            return View();
        }
        public ActionResult timu(yamahainfo i)
        {
            var yy = db.yamahaTimu.ToList();
            var ss = (from p in yy orderby Guid.NewGuid() select p).Take(1).SingleOrDefault();
            ViewBag.t = ss.timu;
            ViewBag.a = ss.A;
            ViewBag.b = ss.B;
            ViewBag.c = ss.C;
            ViewBag.d = ss.D;
            ViewBag.e = ss.E;
            i.openid = "wangli";
            i.wenti = Request.Form["wenti"];
            i.daan = Request.Form["t1"];
            //i.wtime = Convert.ToDateTime(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            i.wtime = DateTime.Now;          
            if (Request.Form["t1"]==ss.E)
            {
                i.shif = 0;
            }
            else
            {
                i.shif = 1;
            }
            db.yamahainfo.Add(i);
            db.SaveChanges();
            return View();
        }
        public ActionResult peiduigame()
        {
            return View();
        }
        public ActionResult complete()
        {
            return View();
        }
    }
}