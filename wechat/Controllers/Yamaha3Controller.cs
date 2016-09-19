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
        public ActionResult zong() {
            return View();
        }
        [HttpPost]
        public ActionResult zong(record r)
        {

            int zhishi = (from s in db.record where s.aName == "知识王" && s.rName == "aaa" && s.time.Value.Day == DateTime.Now.Day select s).Count();
            int manhua = (from s in db.record where s.aName == "Q版漫画" && s.rName == "aaa" && s.time.Value.Day == DateTime.Now.Day select s).Count();
            int game = (from s in db.record where s.aName == "配对游戏" && s.rName == "aaa" && s.time.Value.Day == DateTime.Now.Day select s).Count();
            int rule= (from s in db.record where s.aName == "游戏规则" && s.rName == "aaa" && s.time.Value.Day == DateTime.Now.Day select s).Count();
            //判断是否点击知识王
            if (Request.Form["zhishiwang"] != null)
            {
                if (zhishi >= 1)
                {
                    return RedirectToAction("timu");
                }
                else
                {
                    r.aName = Request.Form["zhishiwang"];
                    r.rName = "aaa";
                    r.time = DateTime.Now;
                    db.record.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("timu");
                }
            }
            if (Request.Form["manhua"] != null)
            {
                r.aName = Request.Form["manhua"];
                r.rName = "aaa";
                r.time = DateTime.Now;
                if (manhua >= 1)
                {
                    return RedirectToAction("manhua2");
                }
                else
                {
                    db.record.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("manhua2");
                }
            }
            if (Request.Form["game"] != null)
            {
               
                if (game >= 1)
                {
                    return RedirectToAction("peiduigame");
                }
                else
                {
                    r.aName = Request.Form["game"];
                    r.rName = "aaa";
                    r.time = DateTime.Now;
                    db.record.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("peiduigame");
                }
            }
            if (Request.Form["rule"] != null)
            {
                if (rule >= 1)
                {
                    return RedirectToAction("rule");
                }
                else
                {
                    r.aName = Request.Form["rule"];
                    r.rName = "aaa";
                    r.time = DateTime.Now;
                    db.record.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("rule");
                }
            }
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
                i.openid = "aaa";
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

           int ii= db.yamahainfo.Where(w => w.openid.Equals("aaa")).Count();
            if (ii >= 5)
            {
                return RedirectToAction("complete");
            }
            return RedirectToAction("timu");
        }
        public ActionResult complete()
        {
            var scores = (from s in db.yamahainfo where s.shif == "true" && s.openid == "aaa" select s).Count();
            ViewBag.num = scores;
            return View();
        }
        public ActionResult peiduigame()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult peiduigame()
        //{
        //    int first = Convert.ToInt32(Request.Form["machine1Result1"]);
        //    int second = Convert.ToInt32(Request.Form["machine1Result2"]);
        //    int third = Convert.ToInt32(Request.Form["machine1Result3"]);

        //    return View();
        //}
        //点击Q版漫画进入的页面
        public ActionResult manhua2() {
            return View();
        }
        //人物介绍
        public ActionResult person() {
            return View();
        }
        //奏响青春管乐梦
        public ActionResult music()
        {
            return View();
        }
        public ActionResult peiduicucess()

        {
            return View();
        }
        public ActionResult rule() {
            return View();
        }
    }
}
