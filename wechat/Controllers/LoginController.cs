using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class LoginController : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult XingHe(string code)
        {
            Utils.WeHelper.appid = "wx7da1972d9ac96dc1";
            Utils.WeHelper.secret = "b2733c2b8663e5c325ef0f0c41e9197e";
            if (!string.IsNullOrWhiteSpace(code))
            {
                Utils.WeHelper.code = code;
                try
                {
                    string strjson = Utils.WeHelper.GetOpenidBycode();

                    //string strjson = "{\"openid\":\"oQOyyv - MdUWSgP8_Smoh2S_6 - 1I0\",\"nickname\":\"白鹤\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"长宁\",\"province\":\"上海\",\"country\":\"中国\",\"headimgurl\":\"http://wx.qlogo.cn/mmopen/78EkX665csCmkBmDBDSYTDCmZdvlMDqCX7wYTLcHeeKNeLicSS5ic2fDAYpeTqicaqhF8Iw9Rp9d6hegynMHC7tPMWLRnqMvNicn/0\",\"privilege\":[]}";
                    Utils.Log.Info("userin", strjson);
                    Models.WechatUser jd = LitJson.JsonMapper.ToObject<Models.WechatUser>(strjson);

                    string openid = jd.openid;

                    int ii = db.WechatUsers.Where(w => w.openid == openid).Count();

                    if (ii == 0)
                    {
                        try
                        {
                            db.WechatUsers.Add(jd);

                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            Utils.Log.Info("xinghe2login", ex.Message );
                        }

                        System.Web.HttpContext.Current.Session["openid"] = openid;
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["openid"] = openid;
                  
                    }




                }
                catch (Exception ex)
                {

                    Utils.Log.Error("userAdd", ex.Message);


                }
            }
            else
            {
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Utils.WeHelper.appid + "&redirect_uri=http://mvc.cjoy.cn/login/xinghe&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            return RedirectToAction("index","xinghe2");
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