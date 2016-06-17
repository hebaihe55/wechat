using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Meiji1Controller : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Meiji1
        public ActionResult Index(string code)
        {
            Utils.WeHelper.appid = "wx36e10017571c25e2";
            Utils.WeHelper.secret = "99203a1e5c88f7aac606f9202b64bdd8";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "meiji" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

           
            if (!string.IsNullOrWhiteSpace(code))
            {
                Utils.WeHelper.code = code;

                string strjson = Utils.WeHelper.GetUserInfo();

                //string strjson = "{\"openid\":\"oQOyyv - MdUWSgP8_Smoh2S_6 - 1I0\",\"nickname\":\"白鹤\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"长宁\",\"province\":\"上海\",\"country\":\"中国\",\"headimgurl\":\"http://wx.qlogo.cn/mmopen/78EkX665csCmkBmDBDSYTDCmZdvlMDqCX7wYTLcHeeKNeLicSS5ic2fDAYpeTqicaqhF8Iw9Rp9d6hegynMHC7tPMWLRnqMvNicn/0\",\"privilege\":[]}";
                Utils.Log.Info("userin", strjson);
                Models.WechatUser jd = LitJson.JsonMapper.ToObject<Models.WechatUser>(strjson);

                jd.cctime = DateTime.Now;
                jd.sourceid = "gh_8e3ff9971691";


                try
                {
                    var wu = db.WechatUsers.SingleOrDefault(w => w.openid == jd.openid);

                    if (wu == null)
                    {
                        db.WechatUsers.Add(jd);

                        db.SaveChanges();

                        System.Web.HttpContext.Current.Session["openid"] = jd.openid;
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["openid"] = wu.openid;
                    }


                }
                catch (Exception ex)
                {

                    Utils.Log.Error("userAdd", ex.Message);
                }
            }
            else
            {
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid="+ Utils.WeHelper.appid + "&redirect_uri=http://mvc.cjoy.cn/meiji1/index&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            //AppID(应用ID)wxa25b827fd42bdf7f
            //AppSecret(应用密钥)00639e0733e2c80d822ccd6a3cbdac51

          
            return View();
        }


       
        public ActionResult b0()
        {
           
            Utils.WeHelper.url = Request.Url.ToString();
            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;

            return View();
        }

         
        public ActionResult bn0(Models.MeijiImg img)
        {

              Utils.WeHelper.MEDIA_ID = img.img1;


              ViewBag.imgname ="http://mvc.cjoy.cn/upimg/"+ Utils.WeHelper.GetMultimedia();
            //ViewBag.imgname = "http://mvc.cjoy.cn/upimg/JpGvViXWaa1Blu61jtAkU9fv_JumT9-XnD2PcE34J1zNuA3UyGA8Nrl2ZkPkPwWq.jpg";
            ViewBag.title = img.title;

            img.imgType = 0;

            System.Web.HttpContext.Current.Session["img"] = img;

            return View();
        }
        public ActionResult b1()
        {

            //Utils.WeHelper.url = Request.Url.ToString();




            //ViewBag.signature = Utils.WeHelper.signature;
            //ViewBag.noncestr = Utils.WeHelper.noncestr;
            //ViewBag.timestamp = Utils.WeHelper.timestamp;
            //ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult bn1(Models.MeijiImg img)
        {
            Utils.WeHelper.MEDIA_ID = img.img1;


            ViewBag.imgname = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();
            //ViewBag.imgname = "http://mvc.cjoy.cn/upimg/JpGvViXWaa1Blu61jtAkU9fv_JumT9-XnD2PcE34J1zNuA3UyGA8Nrl2ZkPkPwWq.jpg";
            ViewBag.title = img.title;
            img.imgType = 1;

            System.Web.HttpContext.Current.Session["img"] = img;

            return View();
        }

        public ActionResult b2()
        {
            Utils.WeHelper.url = Request.Url.ToString();




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }

        public ActionResult bn2(Models.MeijiImg img)
        {
            Utils.WeHelper.MEDIA_ID = img.img1;


            ViewBag.img1= "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();

            //ViewBag.imgname = "http://mvc.cjoy.cn/upimg/JpGvViXWaa1Blu61jtAkU9fv_JumT9-XnD2PcE34J1zNuA3UyGA8Nrl2ZkPkPwWq.jpg";
            Utils.WeHelper.MEDIA_ID = img.img2;


            ViewBag.img2 = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();


            ViewBag.title = img.title;
            img.imgType = 2;

            System.Web.HttpContext.Current.Session["img"] = img;
            return View();
        }

        public ActionResult b3()
        {
            Utils.WeHelper.url = Request.Url.ToString();




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }

        public ActionResult bn3(Models.MeijiImg img)
        {
            Utils.WeHelper.MEDIA_ID = img.img1;


            ViewBag.img1 = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();

            //ViewBag.imgname = "http://mvc.cjoy.cn/upimg/JpGvViXWaa1Blu61jtAkU9fv_JumT9-XnD2PcE34J1zNuA3UyGA8Nrl2ZkPkPwWq.jpg";
            Utils.WeHelper.MEDIA_ID = img.img2;


            ViewBag.img2 = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();


            ViewBag.title = img.title;

            img.imgType = 3;

            System.Web.HttpContext.Current.Session["img"] = img;
            return View();
          
        }

        public ActionResult b4()
        {
            Utils.WeHelper.url = Request.Url.ToString();




            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult bn4(Models.MeijiImg img)
        {
            Utils.WeHelper.MEDIA_ID = img.img1;


            ViewBag.img1 = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();

            //ViewBag.imgname = "http://mvc.cjoy.cn/upimg/JpGvViXWaa1Blu61jtAkU9fv_JumT9-XnD2PcE34J1zNuA3UyGA8Nrl2ZkPkPwWq.jpg";
            Utils.WeHelper.MEDIA_ID = img.img2;


            ViewBag.img2 = "http://mvc.cjoy.cn/upimg/" + Utils.WeHelper.GetMultimedia();


            ViewBag.title = img.title;
            img.imgType = 4;

            System.Web.HttpContext.Current.Session["img"] = img;

            return View();
        }

        public ActionResult bs0(Models.MeijiImg img)
        {

            ViewBag.img1 = img.img1;


            ViewBag.img2 = img.img2;


            ViewBag.title = img.title;
            return View();
        }

       
        public ActionResult bs1(Models.MeijiImg img)
        {
            ViewBag.img1 = img.img1;


            ViewBag.img2 = img.img2;


            ViewBag.title = img.title;

            return View();
        }
        public ActionResult bs2(Models.MeijiImg img)
        {
            ViewBag.img1 = img.img1;


            ViewBag.img2 = img.img2;


            ViewBag.title = img.title;
            return View();
        }
        public ActionResult bs3(Models.MeijiImg img)
        {
            ViewBag.img1 = img.img1;


            ViewBag.img2 = img.img2;


            ViewBag.title = img.title;
            return View();
        }
        public ActionResult bs4(Models.MeijiImg img)
        {
            ViewBag.img1 = img.img1;


            ViewBag.img2 = img.img2;


            ViewBag.title = img.title;
            return View();
        }


        public ActionResult gifts()
        {
            return View();
        }

        public ActionResult show(int id)
        {
            if (id == 0)
            {
                RedirectToAction("bn0", (Models.MeijiImg)Session["img"]);
            }
            else if (id == 1)
            {
                RedirectToAction("bn1", (Models.MeijiImg)Session["img"]);
            }
            else if (id == 2)
            {
                RedirectToAction("bn2", (Models.MeijiImg)Session["img"]);
            }
            else if (id == 3)
            {
                RedirectToAction("bn3", (Models.MeijiImg)Session["img"]);
            }
            else if (id == 4)
            {
                RedirectToAction("bn4", (Models.MeijiImg)Session["img"]);
            }
            return View();
        }

        public ActionResult thank()
        {

            ViewBag.imgtype = ((Models.MeijiImg)Session["img"]).imgType;
            return View();
        }

    }
}