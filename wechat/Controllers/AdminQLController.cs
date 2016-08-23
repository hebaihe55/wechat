using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wechat.Models;

namespace wechat.Controllers
{
    public class AdminQLController : Controller
    {
        private WechatDBContext db = new WechatDBContext();

        // GET: AdminQL
        public ActionResult Index()
        {
            return View(db.GGKs.Where(w=>w.actname.Equals("麒麟啤酒青春bar到")).ToList());
        }

        // GET: AdminQL/Details/5
        public ActionResult Details(string  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          var gGK = db.ImgActives.First(w=>w.openid.Equals(id));
            if (gGK == null)
            {
                return HttpNotFound();
            }
            return View(gGK);
        }

        // GET: AdminQL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminQL/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,openid,name,mobile,addr,prize,actname,flag,cctime")] GGK gGK)
        {
            if (ModelState.IsValid)
            {
                db.GGKs.Add(gGK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gGK);
        }

        // GET: AdminQL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGK gGK = db.GGKs.Find(id);
            if (gGK == null)
            {
                return HttpNotFound();
            }
            return View(gGK);
        }

        // POST: AdminQL/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,openid,name,mobile,addr,prize,actname,flag,cctime")] GGK gGK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gGK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gGK);
        }

        // GET: AdminQL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GGK gGK = db.GGKs.Find(id);
            if (gGK == null)
            {
                return HttpNotFound();
            }
            return View(gGK);
        }

        // POST: AdminQL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GGK gGK = db.GGKs.Find(id);
            db.GGKs.Remove(gGK);
            db.SaveChanges();
            return RedirectToAction("Index");
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
