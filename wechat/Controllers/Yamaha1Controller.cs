using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wechat.Controllers
{
    public class Yamaha1Controller : Controller
    {
        private wechat.Models.WechatDBContext db = new Models.WechatDBContext();
        // GET: Yamaha1


        public ActionResult Login(string code)
        {

            Utils.WeHelper.appid = "wx52d041442fbddbec";
            Utils.WeHelper.secret = "5041fed711106842c0f84b75f84bacea";
            Utils.WeHelper.url = Request.Url.ToString();
            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "yamaha" + DateTime.Now.ToString("yyyyMMddhhmmssfff");

            if (!string.IsNullOrWhiteSpace(code))
            {
                Utils.WeHelper.code = code;

                string strjson = Utils.WeHelper.GetUserInfo();

                if (strjson.IndexOf("errcode") > 0)
                {
                    Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Utils.WeHelper.appid + "&redirect_uri=http://test.cjoy.cn/yamaha1/Login&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
                }


                //string strjson = "{\"openid\":\"oQOyyv - MdUWSgP8_Smoh2S_6 - 1I0\",\"nickname\":\"白鹤\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"长宁\",\"province\":\"上海\",\"country\":\"中国\",\"headimgurl\":\"http://wx.qlogo.cn/mmopen/78EkX665csCmkBmDBDSYTDCmZdvlMDqCX7wYTLcHeeKNeLicSS5ic2fDAYpeTqicaqhF8Iw9Rp9d6hegynMHC7tPMWLRnqMvNicn/0\",\"privilege\":[]}";
                Utils.Log.Info("userin", strjson);
                Models.WechatUser jd = LitJson.JsonMapper.ToObject<Models.WechatUser>(strjson);

                jd.cctime = DateTime.Now;
                jd.sourceid = "gh_971744a1b413";

                string jons = Utils.WeHelper.GetUserInfo(jd.openid);

                Utils.Log.Info("jons", jons);

                LitJson.JsonData jd1 = LitJson.JsonMapper.ToObject(jons);

                if (jd1["subscribe"].ToString() != "1")
                {
                    return RedirectToAction("guanzhu");

                }
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
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Utils.WeHelper.appid + "&redirect_uri=http://test.cjoy.cn/yamaha1/Login&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            //AppID(应用ID)wxa25b827fd42bdf7f
            //AppSecret(应用密钥)00639e0733e2c80d822ccd6a3cbdac51

            return RedirectToAction("index");

        }




        [HttpPost]
        public void shared()
        {
            Models.WechatShare we = new Models.WechatShare();
            we.openid = Session["openid"].ToString();

            we.shareType = "分享";
            we.actName = "雅马哈看视频赢大奖";
            we.cctime = DateTime.Now;


            try
            {
                db.WechatShares.Add(we);
                db.SaveChanges();
            }
            catch (Exception ex)
            {



                Utils.Log.Error("shared", ex.Message);
            }

        }


        public ActionResult Index()
        {
         
            string openid= Session["openid"].ToString();

         int i =  db.WechatShares.Where(w => w.openid.Equals(openid) && w.shareType.Equals("分享")).Count();
            int j = db.WechatShares.Where(w => w.openid.Equals(openid) && w.shareType.Equals("参加")).Count();

            if (i + 1 > j)
            {


                return View();
            }
            else
            {
                return RedirectToAction("thank");
            }
        }

        public ActionResult rule()
        {
            return View();
        }
        public ActionResult subinfo()
        {
            return View();
        }
        public ActionResult t1()
        {
            return View();
        }
        public ActionResult t2()
        {
            return View();
        }
        public ActionResult t3()
        {
            return View();
        }
        public ActionResult t4()
        {
            return View();
        }
        public ActionResult t5()
        {
            return View();
        }
        public ActionResult t6()
        {
            return View();
        }
        public ActionResult t7()
        {
            return View();
        }

        public ActionResult t8()
        {
            return View();
        }
        public ActionResult t9()
        {
            return View();
        }
        public ActionResult t10()
        {
            return View();
        }

        [HttpPost]
        public string addcode(string id)
        {
            string code = DateTime.Now.ToString("mssfff");


            string url = "http://www.cl10086.com/garden/interface/sendSMS.action";

            NameValueCollection nv = new NameValueCollection();

            nv.Add("phone", id.Trim());
            nv.Add("port", "333");
            nv.Add("user", "vipshanghai");
            nv.Add("pass", "cheerlong,,");
            nv.Add("content", "您的验证码是：" + code + "【雅马哈】");

            string aa=  Utils.HttpService.sendLTSms(url,nv);
            return code;

        }

        public ActionResult thank()
        {
            Models.WechatShare we = new Models.WechatShare();
            we.openid = Session["openid"].ToString();

            we.shareType = "参加";
            we.actName = "雅马哈看视频赢大奖";
            we.cctime = DateTime.Now;


            try
            {
                db.WechatShares.Add(we);
                db.SaveChanges();
            }
            catch (Exception ex)
            {



                Utils.Log.Error("shared", ex.Message);
            }

            Utils.WeHelper.appid = "wx52d041442fbddbec";
            Utils.WeHelper.secret = "5041fed711106842c0f84b75f84bacea";

            Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            Utils.WeHelper.noncestr = "yamaha" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
            
            Utils.WeHelper.url = Request.Url.ToString();
            ViewBag.signature = Utils.WeHelper.signature;
            ViewBag.noncestr = Utils.WeHelper.noncestr;
            ViewBag.timestamp = Utils.WeHelper.timestamp;
            ViewBag.appid = Utils.WeHelper.appid;
            return View();
        }
        public ActionResult timu()
        {
            return View();
        }
        public ActionResult guaguaka()
        {
            int i = Utils.Utils.GetRandom();
            string prize = "";
            if (i > 1000)
            {
                var jj = db.GGKs.Where(w => w.prize.Equals("雅马哈电子琴"));


                if (jj.Count() < 3)
                {
                    prize = "雅马哈电子琴";
                }
                else
                {
                    prize = "谢谢参与";
                }
                
            }
            else if (i > 950 && i <= 990)
            {

                var jj = db.GGKs.Where(w => w.prize.Equals("马克西姆签名专辑"));


                if (jj.Count() < 10)
                {
                    prize = "马克西姆签名专辑";
                }
                else
                {
                    prize = "谢谢参与";
                }


               
            }
            else if (i > 900 && i <= 950)
            {


               var jj = db.GGKs.Where(w => w.prize.Equals("雅马哈耳机"));
              

                if (jj.Count() < 50)
                {
                    prize = "雅马哈耳机";
                }
                else
                {
                    prize = "谢谢参与";
                }
                
            }
            else if (i > 50 && i <= 90)
            {

                //活动为2000份，每天发放142份
                var jj = db.GGKs.Where(w => w.prize.Equals("手机流量包") );
                var ii = db.GGKs.Where(w => w.prize.Equals("手机流量包") && w.cctime.Day.Equals(DateTime.Now.Day));

                if (jj.Count() < 2000 && ii.Count() < 142)
                {
                    string openid = Session["openid"].ToString();

                    //参加过为谢谢参与
                    if (db.GGKs.Where(w => w.prize.Equals("手机流量包") && w.openid.Equals(openid)).Count() != 0)
                    {
                        prize = "谢谢参与";
                    }
                    else
                    {
                        prize = "手机流量包";
                    }
                }
                else
                {
                    prize = "谢谢参与";
                }


            }
            else
            {
                prize = "谢谢参与";
            }


            ViewBag.prize = prize;

            System.Web.HttpContext.Current.Session["prize"] = prize;

            return View();
        }
        public ActionResult gethongbaosubinfo()
        {
            return View();
        }
        public ActionResult getawardsubinfo()
        {
            return View();
        }
        public ActionResult thanknobutton()
        {
            return View();
        }
        public ActionResult guanzhu()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLL(Models.GGK ggk)
        {
           
            ggk.actname = "雅马哈看视频赢大奖";
            ggk.flag = 0;
            ggk.openid = Session["openid"].ToString();
            ggk.cctime = DateTime.Now;

            HttpCookie hc = Request.Cookies["cookiename"];

            Models.Question Q = new Models.Question();

            Q.actname = ggk.actname;
            Q.openid = ggk.openid;
            Q.name = ggk.name;
            Q.mobile = ggk.mobile;
            Q.addr = ggk.addr;
            Q.cctime = ggk.cctime;
            Q.answer = hc.Value;








            Models.Updata ud = new Models.Updata();

            ud.activeName = ggk.actname;
            ud.mobile = ggk.mobile;
            ud.openid = ggk.openid;
            ud.cctime = ggk.cctime;

            ud.ISP = Utils.Utils.ISPCheck(ud.mobile);

            ud.fee = 0;

            if (ud.ISP == "移动")
            {
                ud.fee = 30;
            }
            else if (ud.ISP == "联通")
            {
                ud.fee = 20;
            }
            else if (ud.ISP == "电信")
            {
                ud.fee = 30;
            }
            else
            {
                ud.fee = 0;
            }

            try
            {
                db.GGKs.Add(ggk);
                int i = db.SaveChanges();

                db.Question.Add(Q);

                db.SaveChanges();

                if (ggk.prize == "手机流量包")
                {

                    db.Updatas.Add(ud);

                    int ii = db.SaveChanges();


                    if (ii == 1)
                    {
                        string url = "http://3g.qqwa.cn/api/SendMDataPakage_LZY.aspx?t=addorder&timestamp=" + Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();

                        String JsonStr = "{\"signature\":\"wanjing1\",\"token\":\"xinghe\",\"outid\":\"ql12354\",\"mobile\":\"" + ud.mobile + "\",\"amount\":" + ud.fee + "}";


                        Utils.HttpService.PostJson(url, JsonStr);
                    }


                }
            }
            catch (Exception ex)
            {

                Utils.Log.Error("yamaha",ex.Message);
            }






            return RedirectToAction("thank");
        }
        
    }
}