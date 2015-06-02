using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDMWebsite.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            //using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            //{
            //    var a = db.DbFirstTestTables.ToList();
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ConfirmEmail()
        {
            return Content("请到邮箱验证你的用户信息！");
        }

        public ActionResult Test()
        {


            return Content("aaaaaa");
        }

    }


}