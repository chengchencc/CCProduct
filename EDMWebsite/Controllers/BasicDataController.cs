using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDMWebsite.Controllers
{
    public class BasicDataController : Controller
    {
        public EDMContext EDMContext { get; set; }

        public BasicDataController()
        {
            EDMContext = new EDMContext();
        }
        // GET: BasicData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnergyItemDict()
        {
            var model = EDMContext.T_DT_EnergyItemDict.ToList();

            return View(model);
        }

    }
}