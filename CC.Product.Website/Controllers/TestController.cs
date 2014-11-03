using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CC.Product.Website.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSZMail()
        {
            return View();
        }
        public ActionResult DSZMailDSZ()
        {
            return View();
        }
        public ActionResult Add()
        {

            string URI = "http://jgxt/cwbase/WebFramework/loginsso.aspx";
            string myParameters = "usercode=chengch&password=aaaaaa&slmc=gzjg&slbh=gzjg&url=main.htm";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
            }


            return View();
        }
        public ActionResult GetDSZMails()
        {
            List<DSZMailModel> d = new List<DSZMailModel>();
            d.Add(new DSZMailModel() { UserName = "张三", Subject = "关于某某某通知的意见", SendDate = "2014-09-10", State = "未读", Content = "关于某某某通知的意见关于某某某通知的意见关于某某某通知的意见关于某某某通知的意见关于某某某通知的意见", CreateDate = "2014-09-10", ReplyDate = "" });
            d.Add(new DSZMailModel() { UserName = "张三", Subject = "关于某某某通知的意见", SendDate = "2014-09-10", State = "未读", Content = "关于某某某通知的意见", CreateDate = "2014-09-10", ReplyDate = "" });
            d.Add(new DSZMailModel() { UserName = "张三", Subject = "关于某某某通知的意见", SendDate = "2014-09-10", State = "已读", Content = "关于某某某通知的意见", CreateDate = "2014-09-10", ReplyDate = "" });
            d.Add(new DSZMailModel() { UserName = "张三", Subject = "关于某某某通知的意见", SendDate = "2014-09-10", State = "已批", Content = "关于某某某通知的意见", CreateDate = "2014-09-10", ReplyDate = "2014-09-20", ReplyContent = "同意" });

            return Content(JsonConvert.SerializeObject(d));
        }

        private class DSZMailModel
        {
            public string Subject { get; set; }

            public string UserName { get; set; }

            public string SendDate { get; set; }

            public string State { get; set; }

            public string Content { get; set; }

            public string ReplyContent { get; set; }

            public string ReplyDate { get; set; }

            public string CreateDate { get; set; }


        }
    }


}