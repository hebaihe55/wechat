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
        WechatEntities4 db = new WechatEntities4();
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
            //var num = yy.Count();
            //for (int i = 0; i < num; i--)
            //{
            //    if (num == 295)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}
            return View();
        }
        public ActionResult complete() {

            return View();
        }
    }
}