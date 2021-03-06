﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.Product.Website.Filters;

namespace CC.Product.Website.Controllers
{
    public class HomeController : Controller
    {
        //[LogIpAttributeFilter]
        public ActionResult Index()
        {
            
            //return Content("");
            return View();
        }

        public ActionResult CompanyIndex()
        {
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

        public ActionResult Map()
        {
            return View();
        }
        public ActionResult WayBook()
        {
            return View();
        }
        public ActionResult ShoppingIndex()
        {
            return View();
        }
    }
}