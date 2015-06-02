using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.EDM.Model.RealEDMDb;

namespace EDMWebsite.Controllers
{
    public class BasicDataController : Controller
    {
        public RealEDMDbContext EDMContext { get; set; }
        public WriteableSqlDbContext WSDb { get; set; }
        public BasicDataController()
        {
            EDMContext = new RealEDMDbContext();
        }
        // GET: BasicData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnergyItemDict()
        {
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("/BasicData/EnergyItemDict", "能耗分项");
            ViewData["Breadcrumbs"] = breadcrumbs;


            var model = EDMContext.T_DT_EnergyItemDict.ToList();

            return View(model);
        }

        public ActionResult SchoolInfo()
        {
            return View();
        }



    }
}