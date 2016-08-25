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
        WechatEntities3 db = new WechatEntities3();
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
            i.wtime = Convert.ToDateTime(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            i.wenti = Request.Form["t1"].ToString();
            i.daan = Request.Form["t2"];
            return View();
        }
        public ActionResult complete()
        {
            return View();
        }
    }
}