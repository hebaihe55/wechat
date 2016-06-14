using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LitJson;

namespace wechat.Controllers
{
    public class KamidaController : Controller
    {

        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Kamida
        public ActionResult Index(string code)
        {
            Utils.WeHelper.appid = "wxa25b827fd42bdf7f";
            Utils.WeHelper.secret = "00639e0733e2c80d822ccd6a3cbdac51";


            if (!string.IsNullOrWhiteSpace(code))
            {
                Utils.WeHelper.code = code;

                 string strjson=   Utils.WeHelper.GetUserInfo();

               //string strjson = "{\"openid\":\"oQOyyv - MdUWSgP8_Smoh2S_6 - 1I0\",\"nickname\":\"白鹤\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"长宁\",\"province\":\"上海\",\"country\":\"中国\",\"headimgurl\":\"http://wx.qlogo.cn/mmopen/78EkX665csCmkBmDBDSYTDCmZdvlMDqCX7wYTLcHeeKNeLicSS5ic2fDAYpeTqicaqhF8Iw9Rp9d6hegynMHC7tPMWLRnqMvNicn/0\",\"privilege\":[]}";
                 Utils.Log.Info("userin", strjson);
                Models.WechatUser jd =     LitJson.JsonMapper.ToObject<Models.WechatUser>(strjson);

                jd.cctime = DateTime.Now;
                jd.sourceid = "gh_e778e7122d69";

              
                try
                {
                 var wu=  db.WechatUsers.SingleOrDefault(w => w.openid==jd.openid);

                    if(wu==null)
                    {
                        db.WechatUsers.Add(jd);

                        db.SaveChanges();

                        ViewBag.WechatUserId = jd.WechatUserId;
                    }
                     else
                    {
                        ViewBag.WechatUserId = wu.WechatUserId;
                    }  

                  
                }
                catch (Exception ex)
                {

                    Utils.Log.Error("userAdd", ex.Message);
                }
            }
            else
            {
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxa25b827fd42bdf7f&redirect_uri=http://mvc.cjoy.cn/kamida/index&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            //AppID(应用ID)wxa25b827fd42bdf7f
            //AppSecret(应用密钥)00639e0733e2c80d822ccd6a3cbdac51
            
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "kamida" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature= Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;

            return View();
        }



        [HttpPost]
        public int add( Models.ActiveUpImg au)
        {
            Utils.WeHelper.MEDIA_ID = au.mediaId;
           

            au.imgUrl = Utils.WeHelper.GetMultimedia();

            au.cctime = DateTime.Now;
            int i = 0;
            try
            {
                db.ActiveUpImgs.Add(au);
             i=   db.SaveChanges();
            }
            catch (Exception ex)
            {
                i = -1;
                Utils.Log.Error("imgadd", ex.Message);
            }
            return i;
        }

        public ActionResult Rule()
        {
            Utils.WeHelper.appid = "wxa25b827fd42bdf7f";
            Utils.WeHelper.secret = "00639e0733e2c80d822ccd6a3cbdac51";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "kamida" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }

        public ActionResult Ok()
        {
            Utils.WeHelper.appid = "wxa25b827fd42bdf7f";
            Utils.WeHelper.secret = "00639e0733e2c80d822ccd6a3cbdac51";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "kamida" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }

        public ActionResult Err()
        {
            Utils.WeHelper.appid = "wxa25b827fd42bdf7f";
            Utils.WeHelper.secret = "00639e0733e2c80d822ccd6a3cbdac51";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "kamida" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult Ercode()
        {
            Utils.WeHelper.appid = "wxa25b827fd42bdf7f";
            Utils.WeHelper.secret = "00639e0733e2c80d822ccd6a3cbdac51";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "kamida" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
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