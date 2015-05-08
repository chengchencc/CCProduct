using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDMWebsite.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings
        public ActionResult Index()
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;

            }

            return View();
        }

        public ActionResult OfficeBuildings()
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "行政办公建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;
            }

            return View();
        }
    }
}