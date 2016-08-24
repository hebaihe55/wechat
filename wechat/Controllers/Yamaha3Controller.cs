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
        WechatEntities2 db = new WechatEntities2();
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
            return View(ss );
        }
    }
}