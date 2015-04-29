using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.Entity;

namespace EDMWebsite.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {


            return View();
        }
    }



}