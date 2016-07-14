using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Xinghe2Controller : BaseController
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Xinghe2
        public ActionResult Index()
        {

            string openid = Session["openid"].ToString();

          

            return View();
        }
        public ActionResult rule()
        {
            return View();
        }



        public ActionResult thank()
        {
            return View();
        }
        public ActionResult thank2()
        {
            return View();
        }
        public ActionResult thank4()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult add(Models.GGK ggk)
        {
            if (ModelState.IsValid)
            {
                ggk.actname = "兴和集邮票活动";
                ggk.cctime = DateTime.Now;
                ggk.openid = Session["openid"].ToString();
                ggk.flag = 0;


                if (ggk.prize == "一等奖")
                {
                    db.GGKs.Add(ggk);
                    db.SaveChanges();
                    return RedirectToAction("thank3");
                }
                else if (ggk.prize == "二等奖")
                {
                    db.GGKs.Add(ggk);
                    db.SaveChanges();

                    return RedirectToAction("thank2");
                }
                else if (ggk.prize == "三等奖")
                {



                    Models.Updata ud = new Models.Updata();

                    ud.activeName = ggk.actname;
                    ud.mobile = ggk.mobile;
                    ud.openid = ggk.openid;
                    ud.cctime = ggk.cctime;

                    ud.ISP = Utils.Utils.ISPCheck(ud.mobile);

                    ud.fee = 0;

                    if (ud.ISP == "移动")
                    {
                        ud.fee = 10;
                    }
                    else if (ud.ISP == "联通")
                    {
                        ud.fee = 20;
                    }
                    else if (ud.ISP == "电信")
                    {
                        ud.fee = 10;
                    }
                    else
                    {
                        ud.fee = 0;
                    }

                    try
                    {
                        db.GGKs.Add(ggk);
                        int ii = db.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        Utils.Log.Error("xinghe2", ex.StackTrace);
                    }
                    db.Updatas.Add(ud);
                    int jj = db.SaveChanges();
                    if (jj == 1)
                    {
                        try
                        {
                            string url = "http://3g.qqwa.cn/api/SendMDataPakage_LZY.aspx?t=addorder&timestamp=" + Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();

                            String JsonStr = "{\"signature\":\"wanjing1\",\"token\":\"xinghe\",\"outid\":\"ql12354\",\"mobile\":\"" + ud.mobile + "\",\"amount\":" + ud.fee + "}";


                            Utils.HttpService.PostJson(url, JsonStr);
                        }
                        catch (Exception ex)
                        {

                            Utils.Log.Error("xinghe2liuliang", ex.StackTrace);
                        }
                    }

                    return RedirectToAction("thank");
                }
                else
                {
                    return RedirectToAction("thank2");
                }
            }
            return View();
        }


        public ActionResult getawardliuliang()
        {
            return View();
        }
        public ActionResult gameplay()
        {

            string openid = Session["openid"].ToString();

            int ij = db.GGKs.Where(w => w.openid.Equals(openid) && w.actname.Equals("兴和集邮票活动")).Count();

            if (ij >= 1)
            {
                return RedirectToAction("thank4");
            }


            int i = Utils.Utils.GetRandom();

            if (i > 30)
            {
                ViewBag.pirze = 3;
            }


            return View();
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