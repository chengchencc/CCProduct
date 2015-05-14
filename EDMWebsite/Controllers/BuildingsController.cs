using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;

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

            using (EDMContext edmDb = new EDMContext())
            {
                var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
                List<ZTreeModel> nodes = new List<ZTreeModel>();
                foreach (var item in energyItemDict)
                {
                    ZTreeModel newItem = new ZTreeModel();
                    newItem.id = item.F_EnergyItemCode;
                    newItem.name = item.F_EnergyItemName;
                    newItem.pId = item.F_ParentItemCode;
                    nodes.Add(newItem);
                }

                var jsonNodes = JsonConvert.SerializeObject(nodes);

                ViewData["TypeNodes"] = jsonNodes;
                List<SelectListItem> energyType = new List<SelectListItem>();
                foreach (var item in energyItemDict)
                {
                    SelectListItem si = new SelectListItem();
                    si.Text = item.F_EnergyItemName;
                    si.Value = item.F_EnergyItemCode;
                    energyType.Add(si);
                }
                ViewData["EnergyType"] = energyType;
                //ViewData["EnergyType1"] = energyItemDict;
            }


            //Generate breadcrumbs
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("", "建筑能耗对比");
            ViewData["Breadcrumbs"] = breadcrumbs;

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpGet]
        public ActionResult OfficeBuildings()
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "行政办公建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;
            }
            using (EDMContext edmDb = new EDMContext())
            {
                var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s=>s.F_EnergyItemCode).ToList();
                List<ZTreeModel> nodes = new List<ZTreeModel>();
                foreach (var item in energyItemDict)
                {
                    ZTreeModel newItem = new ZTreeModel();
                    newItem.id = item.F_EnergyItemCode;
                    newItem.name = item.F_EnergyItemName;
                    newItem.pId = item.F_ParentItemCode;
                    nodes.Add(newItem);
                }

                var jsonNodes = JsonConvert.SerializeObject(nodes);

                ViewData["TypeNodes"] = jsonNodes;
                List<SelectListItem> energyType = new List<SelectListItem>();
                foreach (var item in energyItemDict)
                {
                    SelectListItem si = new SelectListItem();
                    si.Text = item.F_EnergyItemName;
                    si.Value = item.F_EnergyItemCode;
                    energyType.Add(si);
                }
                ViewData["EnergyType"] = energyType;
                //ViewData["EnergyType1"] = energyItemDict;
            }


            //Generate breadcrumbs
            Dictionary<string,string> breadcrumbs = new Dictionary<string,string>();
            breadcrumbs.Add("http://www.baidu.com","建筑能耗监控");
            breadcrumbs.Add("/buildings/xz","行政办公室");
            breadcrumbs.Add("/buildings/TheOffice","办公室");
            ViewData["Breadcrumbs"] = breadcrumbs;

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult OfficeBuildings(QueryModel model)
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "行政办公建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;
            }
            using (EDMContext edmDb = new EDMContext())
            {
                var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
                List<ZTreeModel> nodes = new List<ZTreeModel>();
                foreach (var item in energyItemDict)
                {
                    ZTreeModel newItem = new ZTreeModel();
                    newItem.id = item.F_EnergyItemCode;
                    newItem.name = item.F_EnergyItemName;
                    newItem.pId = item.F_ParentItemCode;
                    nodes.Add(newItem);
                }

                var jsonNodes = JsonConvert.SerializeObject(nodes);

                ViewData["TypeNodes"] = jsonNodes;
                List<SelectListItem> energyType = new List<SelectListItem>();
                foreach (var item in energyItemDict)
                {
                    SelectListItem si = new SelectListItem();
                    si.Text = item.F_EnergyItemName;
                    si.Value = item.F_EnergyItemCode;
                    energyType.Add(si);
                }
                ViewData["EnergyType"] = energyType;
                //ViewData["EnergyType1"] = energyItemDict;
            }


            //Generate breadcrumbs
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("http://www.baidu.com", "建筑能耗监控");
            breadcrumbs.Add("/buildings/xz", "行政办公室");
            breadcrumbs.Add("/buildings/TheOffice", "办公室");
            ViewData["Breadcrumbs"] = breadcrumbs;


            model.Result = new Dictionary<string, string>();
            model.Result.Add("01", "0kw");
            model.Result.Add("02", "0kw");
            model.Result.Add("03", "0kw");
            model.Result.Add("04", "0kw");
            model.Result.Add("05", "0kw");
            model.Result.Add("06", "0kw");
            model.Result.Add("07", "0kw");
            model.Result.Add("08", "0kw");
            model.Result.Add("09", "0kw");
            model.Result.Add("10", "0kw");
            model.Result.Add("11", "0kw");
            model.Result.Add("12", "0kw");


            return View(model);
        }

    }
}