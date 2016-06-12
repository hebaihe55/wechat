using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Xinghe1Controller : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Xinghe1
        public ActionResult Index(string code)
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
                LitJson.JsonData jd = LitJson.JsonMapper.ToObject(strjson);

              string openid=  jd["openid"].ToString();


                
                    var wu = db.Question.SingleOrDefault(w => w.openid.Equals(openid));

                    if (wu == null)
                    {


                        ViewBag.openid = openid;
                      
                    }
                    else
                    {
                        return RedirectToAction("Thanks");
                    }


                }
                catch (Exception ex)
                {

                    Utils.Log.Error("userAdd", ex.Message);

                  
                }
            }
            else
            {
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Utils.WeHelper.appid + "&redirect_uri=http://mvc.cjoy.cn/Xinghe1/index&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect");
            }

        
            return View();
        }

        [HttpPost]
        public ActionResult Add(Models.Question question)
        {
            question.cctime = DateTime.Now;

            question.addr = "未知";

            question.actname = "兴和问答";

            try
            {
                db.Question.Add(question);

                db.SaveChanges();
            }
            catch (Exception ex)
            {

                Utils.Log.Error("questionAdd", ex.Message);
                return RedirectToAction("Thanks");
            }
           
            return RedirectToAction("Thanks");
        }


        public ActionResult Thanks()
        {
            return View();
        }
    }
}