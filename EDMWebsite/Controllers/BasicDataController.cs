using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CC.EDM.Domain.Services;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models;

namespace EDMWebsite.Controllers
{
    [Authorize(Roles = "admin")]
    public class BasicDataController : Controller
    {
        public RealEDMDbContext EDMContext { get; set; }
        public WriteableSqlDbContext WSDb { get; set; }
        public ISyncDataService SyncDataService { get; set; }
        public BasicDataController(ISyncDataService syncDataService)
        {
            EDMContext = new RealEDMDbContext();
            SyncDataService = syncDataService;
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

        public ActionResult SyncData()
        {

            return View();
        }

        public ActionResult MySqlTest()
        {
            var result = string.Empty;
            using (DeviceDbContext db = new DeviceDbContext())
            {
                var tbdata = db.tb_data.Take(10).ToList();

                foreach (var item in tbdata)
                {
                    result += item.macip;
                }
            }
            return Content(result);
        }

        public ActionResult SyncAllData()
        {
            SyncDataService.SyncEnergyItemData();
            SyncDataService.SyncEnergyHourData();
            SyncDataService.SyncEnergyDayData();
            SyncDataService.SyncEnergyMonthData();

            return Content("同步完成");
        }

    }
}