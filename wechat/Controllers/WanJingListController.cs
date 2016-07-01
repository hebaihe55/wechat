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
    public class WanJingListController : Controller
    {
        private WechatDBContext db = new WechatDBContext();

        // GET: WanJingList
        public ActionResult Index()
        {
            return View(db.GGKs.Where(w=>w.actname.Contains("暑假大抽奖")).ToList());
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
