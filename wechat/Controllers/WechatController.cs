using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace wechat.Controllers
{
    public class WechatController : Controller
    {
        // GET: Wechat
        public ActionResult Index()
        {
            return View();
        }
        public string Api(string echostr)
        {
            if (echostr == "")
            {
                return "success";

            }
            return echostr;
        }

        [HttpPost]
        public void Api()
        {

            Stream st = Request.InputStream;

            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8"));

            String xmlStr = sr.ReadToEnd();

            Utils.Log.Info("apire", xmlStr);


            XElement root = XElement.Parse(xmlStr);


            DoWithReceive(root);





        }

        private string  DoWithReceive(XElement root)
        {
            if (root.Element("ToUserName").Equals("gh_27b3dec618b6"))
            {
                if (root.Element("Event").Equals("subscribe"))
                {

                    return "";
                }
            }

            return "";
        }

    
   

   

    }
}