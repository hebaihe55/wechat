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
    public class AdminKamidaController : Controller
    {
        private WechatDBContext db = new WechatDBContext();

        // GET: AdminKamida
        public ActionResult Index()
        {
            var activeUpImgs = db.ActiveUpImgs.Include(a => a.WechatUser);
            return View(activeUpImgs.ToList());
        }

        // GET: AdminKamida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveUpImg activeUpImg = db.ActiveUpImgs.Find(id);
            if (activeUpImg == null)
            {
                return HttpNotFound();
            }
            return View(activeUpImg);
        }

        // GET: AdminKamida/Create
        public ActionResult Create()
        {
            ViewBag.WechatUserId = new SelectList(db.WechatUsers, "WechatUserId", "openid");
            return View();
        }

        // POST: AdminKamida/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActiveUpImgId,mediaId,imgUrl,cctime,WechatUserId")] ActiveUpImg activeUpImg)
        {
            if (ModelState.IsValid)
            {
                db.ActiveUpImgs.Add(activeUpImg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WechatUserId = new SelectList(db.WechatUsers, "WechatUserId", "openid", activeUpImg.WechatUserId);
            return View(activeUpImg);
        }

        // GET: AdminKamida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveUpImg activeUpImg = db.ActiveUpImgs.Find(id);
            if (activeUpImg == null)
            {
                return HttpNotFound();
            }
            ViewBag.WechatUserId = new SelectList(db.WechatUsers, "WechatUserId", "openid", activeUpImg.WechatUserId);
            return View(activeUpImg);
        }

        // POST: AdminKamida/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActiveUpImgId,mediaId,imgUrl,cctime,WechatUserId")] ActiveUpImg activeUpImg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activeUpImg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WechatUserId = new SelectList(db.WechatUsers, "WechatUserId", "openid", activeUpImg.WechatUserId);
            return View(activeUpImg);
        }

        // GET: AdminKamida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveUpImg activeUpImg = db.ActiveUpImgs.Find(id);
            if (activeUpImg == null)
            {
                return HttpNotFound();
            }
            return View(activeUpImg);
        }

        // POST: AdminKamida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActiveUpImg activeUpImg = db.ActiveUpImgs.Find(id);
            db.ActiveUpImgs.Remove(activeUpImg);
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
