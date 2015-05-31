using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;

namespace EDMWebsite.Controllers
{
    public class QueryController : BaseController
    {
        public WriteableSqlDbContext WriteableDb { get; set; }
        public RealEDMDbContext edmDb { get; set; }
        public QueryController()
        {
            WriteableDb = new WriteableSqlDbContext();
            edmDb = new RealEDMDbContext();
        }

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
                    //if (item.F_ParentItemCode )
                    //{

                    //}
                    //newItem.nocheck = "true";
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
                var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
                List<ZTreeModel> nodes = new List<ZTreeModel>();
                foreach (var item in energyItemDict)
                {
                    ZTreeModel newItem = new ZTreeModel();
                    newItem.id = item.F_EnergyItemCode;
                    newItem.name = item.F_EnergyItemName;
                    newItem.pId = item.F_ParentItemCode;
                    //newItem.nocheck = "true";

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

        [HttpGet]
        public ActionResult Buildings()
        {
            var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
            List<ZTreeModel> nodes = new List<ZTreeModel>();
            foreach (var item in energyItemDict)
            {
                ZTreeModel newItem = new ZTreeModel();
                newItem.id = item.F_EnergyItemCode;
                newItem.name = item.F_EnergyItemName;
                newItem.pId = item.F_ParentItemCode;
                newItem.nocheck = "false";

                nodes.Add(newItem);
            }

            var jsonNodes = JsonConvert.SerializeObject(nodes);

            //能耗类型下拉框
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

            //建筑下拉框
            List<SelectListItem> buildings = new List<SelectListItem>();
            foreach (var item in WriteableDb.Buildings)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.Name;
                si.Value = item.Id.ToString();
                buildings.Add(si);
            }
            ViewData["Buildings"] = buildings;


            //Generate breadcrumbs
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("http://www.baidu.com", "建筑能耗监控");
            //breadcrumbs.Add("/buildings/xz", "行政办公室");
            //breadcrumbs.Add("/buildings/TheOffice", "办公室");
            ViewData["Breadcrumbs"] = breadcrumbs;

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Buildings(QueryModel model)
        {
            #region 能耗类型
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

            //能耗类型下拉框
            ViewData["TypeNodes"] = jsonNodes;
            //List<SelectListItem> energyType = new List<SelectListItem>();
            //foreach (var item in energyItemDict)
            //{
            //    SelectListItem si = new SelectListItem();
            //    si.Text = item.F_EnergyItemName;
            //    si.Value = item.F_EnergyItemCode;
            //    energyType.Add(si);
            //}
            //ViewData["EnergyType"] = energyType;
            #endregion

            var buildId = "370100D003I01";

            //var re = from energyDayItem in edmDb.T_EC_EnergyItemDayResult
            //         join buildInfo in edmDb.T_BD_BuildBaseInfo on energyDayItem.F_BuildID equals buildInfo.F_BuildID
            //         join energyTypes in edmDb.T_DT_EnergyItemDict on energyDayItem.F_EnergyItemCode equals energyTypes.F_EnergyItemCode
            //         where energyDayItem.F_BuildID == buildId
            //         select new DayResult { EnergyType= energyTypes, EnergyDayResult= energyDayItem, BuildInfo= buildInfo };


            model.DayResult = edmDb.T_EC_EnergyItemDayResult
                .Include("T_BD_BuildBaseInfo")
                .Include("T_DT_EnergyItemDict")
                .Where(s => s.F_BuildID == buildId)
                .ToList();

            //建筑下拉框
            List<SelectListItem> buildings = new List<SelectListItem>();
            foreach (var item in WriteableDb.Buildings)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.Name;
                si.Value = item.Id.ToString();
                buildings.Add(si);
            }
            ViewData["Buildings"] = buildings;


            //Generate breadcrumbs
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("http://www.baidu.com", "建筑能耗监控");
            breadcrumbs.Add("/buildings/xz", "行政办公室");
            breadcrumbs.Add("/buildings/TheOffice", "办公室");
            ViewData["Breadcrumbs"] = breadcrumbs;


            //model.Result = new Dictionary<string, string>();



            return View(model);
        }

        [HttpGet]
        public ActionResult Rooms()
        {

            var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
            List<ZTreeModel> nodes = new List<ZTreeModel>();
            foreach (var item in energyItemDict)
            {
                ZTreeModel newItem = new ZTreeModel();
                newItem.id = item.F_EnergyItemCode;
                newItem.name = item.F_EnergyItemName;
                newItem.pId = item.F_ParentItemCode;
                //newItem.nocheck = "true";

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

            //建筑下拉框
            List<ZTreeModel> roomsNode = new List<ZTreeModel>();
            var buildings = WriteableDb.Buildings.Include("Rooms");

            foreach (var building in buildings)
            {
                ZTreeModel newNode = new ZTreeModel();
                newNode.id = building.Id + "building";
                newNode.name = building.Name;
                newNode.pId = building.Id + "building";
                newNode.nocheck = "true";
                roomsNode.Add(newNode);

                foreach (var room in building.Rooms)
                {
                    ZTreeModel newRoomNode = new ZTreeModel();
                    newRoomNode.id = room.Id.ToString();
                    newRoomNode.name = room.Name;
                    newRoomNode.pId = building.Id + "building";
                    newRoomNode.nocheck = "false";
                    roomsNode.Add(newRoomNode);
                }
            }
            var jsonRoomNodes = JsonConvert.SerializeObject(roomsNode);

            ViewData["RoomNodes"] = jsonRoomNodes;


            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult Rooms(QueryModel model)
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "行政办公建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;
            }

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

            //建筑下拉框
            List<ZTreeModel> roomsNode = new List<ZTreeModel>();
            var buildings = WriteableDb.Buildings.Include("Rooms");

            foreach (var building in buildings)
            {
                ZTreeModel newNode = new ZTreeModel();
                newNode.id = building.Id + "building";
                newNode.name = building.Name;
                newNode.pId = building.Id + "building";
                newNode.nocheck = "true";
                roomsNode.Add(newNode);

                foreach (var room in building.Rooms)
                {
                    ZTreeModel newRoomNode = new ZTreeModel();
                    newRoomNode.id = room.Id.ToString();
                    newRoomNode.name = room.Name;
                    newRoomNode.pId = building.Id + "building";
                    newRoomNode.nocheck = "false";
                    roomsNode.Add(newRoomNode);
                }
            }
            var jsonRoomNodes = JsonConvert.SerializeObject(roomsNode);

            ViewData["RoomNodes"] = jsonRoomNodes;


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


        [HttpGet]
        public ActionResult BuildingsOld()
        {

            //using (EDMContext edmDb = new EDMContext())
            var energyItemDict = edmDb.T_DT_EnergyItemDict.OrderBy(s => s.F_EnergyItemCode).ToList();
            List<ZTreeModel> nodes = new List<ZTreeModel>();
            foreach (var item in energyItemDict)
            {
                ZTreeModel newItem = new ZTreeModel();
                newItem.id = item.F_EnergyItemCode;
                newItem.name = item.F_EnergyItemName;
                newItem.pId = item.F_ParentItemCode;
                newItem.nocheck = "false";

                nodes.Add(newItem);
            }

            var jsonNodes = JsonConvert.SerializeObject(nodes);
            ViewData["TypeNodes"] = jsonNodes;

            //能耗类型下拉框
            List<SelectListItem> energyType = new List<SelectListItem>();
            foreach (var item in energyItemDict)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.F_EnergyItemName;
                si.Value = item.F_EnergyItemCode;
                energyType.Add(si);
            }
            ViewData["EnergyType"] = energyType;

            //建筑下拉框
            List<SelectListItem> buildings = new List<SelectListItem>();
            foreach (var item in edmDb.T_BD_BuildBaseInfo)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.F_BuildName;
                si.Value = item.F_BuildID;
                buildings.Add(si);
            }
            ViewData["Buildings"] = buildings;


            List<ZTreeModel> roomsNode = new List<ZTreeModel>();
            foreach (var buildType in edmDb.BuildTypeInits)
            {
                roomsNode.Add(new ZTreeModel() { id = buildType.contain, name = buildType.typename, nocheck = "true", pId = buildType.contain });
                var childrens = edmDb.T_BD_BuildBaseInfo.Where(s => s.F_BuildID.Contains(buildType.contain));
                foreach (var builditem in childrens)
                {
                    roomsNode.Add(new ZTreeModel() { id = builditem.F_BuildID, name = builditem.F_BuildName, pId = buildType.contain });
                }
            }
            ViewData["BuildingNodes"] = JsonConvert.SerializeObject(roomsNode);


            //Generate breadcrumbs
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("http://www.baidu.com", "建筑能耗监控");
            //breadcrumbs.Add("/buildings/xz", "行政办公室");
            //breadcrumbs.Add("/buildings/TheOffice", "办公室");
            ViewData["Breadcrumbs"] = breadcrumbs;

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public ActionResult BuildingsOld(QueryModel model)
        {
            #region 页面帮助与下拉框数据绑定
            #region 能耗类型
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

            //能耗类型下拉框
            ViewData["TypeNodes"] = jsonNodes;
            //List<SelectListItem> energyType = new List<SelectListItem>();
            //foreach (var item in energyItemDict)
            //{
            //    SelectListItem si = new SelectListItem();
            //    si.Text = item.F_EnergyItemName;
            //    si.Value = item.F_EnergyItemCode;
            //    energyType.Add(si);
            //}
            //ViewData["EnergyType"] = energyType;
            #endregion

            #region 建筑帮助
            List<ZTreeModel> roomsNode = new List<ZTreeModel>();
            foreach (var buildType in edmDb.BuildTypeInits)
            {
                roomsNode.Add(new ZTreeModel() { id = buildType.contain, name = buildType.typename, nocheck = "true", pId = buildType.contain });
                var childrens = edmDb.T_BD_BuildBaseInfo.Where(s => s.F_BuildID.Contains(buildType.contain));
                foreach (var builditem in childrens)
                {
                    roomsNode.Add(new ZTreeModel() { id = builditem.F_BuildID, name = builditem.F_BuildName, pId = buildType.contain });
                }
            }
            ViewData["BuildingNodes"] = JsonConvert.SerializeObject(roomsNode);

            #endregion

            #region 建筑下拉框 （已经不用了）
            //建筑下拉框
            List<SelectListItem> buildings = new List<SelectListItem>();
            foreach (var item in WriteableDb.Buildings)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.Name;
                si.Value = item.Id.ToString();
                buildings.Add(si);
            }
            ViewData["Buildings"] = buildings;
            #endregion
            #endregion

            var codes = model.RoomCodes.Trim().Trim(',').Split(',');

            //var buildId = "370100D003I01";
            //var re = from energyDayItem in edmDb.T_EC_EnergyItemDayResult
            //         join buildInfo in edmDb.T_BD_BuildBaseInfo on energyDayItem.F_BuildID equals buildInfo.F_BuildID
            //         join energyTypes in edmDb.T_DT_EnergyItemDict on energyDayItem.F_EnergyItemCode equals energyTypes.F_EnergyItemCode
            //         where energyDayItem.F_BuildID == buildId
            //         select new DayResult { EnergyType= energyTypes, EnergyDayResult= energyDayItem, BuildInfo= buildInfo };


            var query = edmDb.T_EC_EnergyItemDayResult
                 .Include("T_BD_BuildBaseInfo")
                 .Include("T_DT_EnergyItemDict")
                 .Where(s => codes.Contains(s.F_BuildID));
            if (model.StartDate != null)
            {
               query = query.Where(s => s.F_StartDay > model.StartDate);
            }
            if (model.EndDate != null)
            {
               query = query.Where(s => s.F_EndDay < model.EndDate);
            }
            if (!string.IsNullOrEmpty(model.EnergyTypeCodes)
                &&!string.IsNullOrEmpty(model.EnergyTypeCodes.Trim(',')))
            {
                var energyTypeCodesArray = model.EnergyTypeCodes.Trim(',').Split(',');
                query = query.Where(s=>energyTypeCodesArray.Contains( s.F_EnergyItemCode));
            }
            model.DayResult = query.ToList();

            return View(model);
        }


    }
}