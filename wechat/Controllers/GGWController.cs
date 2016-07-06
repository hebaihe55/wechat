using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class GGWController : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: GGW
        public ActionResult Index()
        {
            return View(db.Updatas.Where(w=>w.activeName.Equals("丸井活动1")).ToList());
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