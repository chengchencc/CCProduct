using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CC.EDM.Model.RealEDMDb;
using EDMWebsite.Models.ViewModels;
using Newtonsoft.Json;
using CC.EDM.Domain.Services;

namespace EDMWebsite.Controllers
{
    [Authorize]
    public class QueryController : BaseController
    {
        public WriteableSqlDbContext WriteableDb { get; set; }
        public RealEDMDbContext edmDb { get; set; }
        public IQueryService QueryService { get; set; }
        public QueryController(IQueryService queryService)
        {
            WriteableDb = new WriteableSqlDbContext();
            edmDb = new RealEDMDbContext();
            QueryService = queryService;
        }

        // GET: Buildings
        public ActionResult Index()
        {
            using (WriteableSqlDbContext db = new WriteableSqlDbContext())
            {
                var buildingSelectors = db.Comdicts.Where(s => s.Type == "建筑").ToList();
                ViewData["Buildings"] = buildingSelectors;

            }

            using (RealEDMDbContext edmDb = new RealEDMDbContext())
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
            using (RealEDMDbContext edmDb = new RealEDMDbContext())
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
            using (RealEDMDbContext edmDb = new RealEDMDbContext())
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
        public ActionResult Rooms()
        {
            GenerateEnergyTypeTreeModel();

            GenerateRoomTree();


            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.ChartSeries = "[]";

            return View(model);
        }


        [HttpPost]
        public ActionResult Rooms(QueryModel model)
        {
            GenerateEnergyTypeTreeModel();
            GenerateRoomTree();
            if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForRooms(model);
            }
            else if(model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForRooms(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForRooms(model);
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Institutes()
        {
            GenerateEnergyTypeTreeModel();

            //学院下拉框
            List<SelectListItem> institutes = new List<SelectListItem>();
            foreach (var item in WriteableDb.Institutes)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.Name;
                si.Value = item.Id.ToString();
                institutes.Add(si);
            }
            ViewData["Institutes"] = institutes;

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(-1);
            model.ChartSeries = "[]";

            return View(model);
        }

        [HttpPost]
        public ActionResult Institutes(QueryModel model)
        {
            #region 帮助绑定
            GenerateEnergyTypeTreeModel();


            //学院下拉框
            List<SelectListItem> institutes = new List<SelectListItem>();
            foreach (var item in WriteableDb.Institutes)
            {
                SelectListItem si = new SelectListItem();
                si.Text = item.Name;
                si.Value = item.Id.ToString();
                institutes.Add(si);
            }
            ViewData["Institutes"] = institutes;
            #endregion

            if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForInstitutes(model);
            }
            else if (model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForInstitutes(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForInstitutes(model);
            }


            return View(model);
        }

        [HttpGet]
        public ActionResult Buildings()
        {
            GenerateEnergyTypeTreeModel();

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


            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now;
            model.ChartSeries = "[]";
            return View(model);
        }

        [HttpPost]
        public ActionResult Buildings(QueryModel model)
        {
            GenerateEnergyTypeTreeModel();
            
            //var re = from energyDayItem in edmDb.T_EC_EnergyItemDayResult
            //         join buildInfo in edmDb.T_BD_BuildBaseInfo on energyDayItem.F_BuildID equals buildInfo.F_BuildID
            //         join energyTypes in edmDb.T_DT_EnergyItemDict on energyDayItem.F_EnergyItemCode equals energyTypes.F_EnergyItemCode
            //         where energyDayItem.F_BuildID == buildId
            //         select new DayResult { EnergyType= energyTypes, EnergyDayResult= energyDayItem, BuildInfo= buildInfo };

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


            if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForBuildings(model);
            }
            else if (model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForBuildings(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForBuildings(model);
            }


            return View(model);
        }

        #region Old Query
        [HttpGet]
        public ActionResult CompareBuildingsOld()
        {
            #region Binding Dictionary Helpers and dropdown list
            GenerateEnergyTypeTreeModel();
            GenerateBuildingTreeModel();
            #endregion

            QueryModel model = new QueryModel();
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddDays(-1);
            model.ChartSeries = "[]";
            return View(model);
        }

        [HttpPost]
        public ActionResult CompareBuildingsOld(QueryModel model)
        {
            #region Binding Dictionary Helpers and dropdown list
            GenerateEnergyTypeTreeModel();
            GenerateBuildingTreeModel();
            #endregion


            //var buildId = "370100D003I01";
            //var re = from energyDayItem in edmDb.T_EC_EnergyItemDayResult
            //         join buildInfo in edmDb.T_BD_BuildBaseInfo on energyDayItem.F_BuildID equals buildInfo.F_BuildID
            //         join energyTypes in edmDb.T_DT_EnergyItemDict on energyDayItem.F_EnergyItemCode equals energyTypes.F_EnergyItemCode
            //         where energyDayItem.F_BuildID == buildId
            //         select new DayResult { EnergyType= energyTypes, EnergyDayResult= energyDayItem, BuildInfo= buildInfo };


            if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForBuildingsOld(model);
            }
            else if (model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForBuildingsOld(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForBuildingsOld(model);
            }



            return View(model);
        }

        [HttpGet]
        public ActionResult BuildingsOld(string id)
        {
            #region Binding Dictionary Helpers and dropdown list
            GenerateEnergyTypeTreeModel();
            GenerateBuildingTreeModel();
            #endregion

            QueryModel model = new QueryModel();
            model.RoomCodes = id;
            model.StartDate = new DateTime(DateTime.Now.Year, 5, DateTime.Now.Day, 0, 0, 0);
            model.EndDate = new DateTime(DateTime.Now.Year, 5, DateTime.Now.Day + 1, 0, 0, 0);
            //model.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            //model.EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1, 0, 0, 0);
            model.ChartSeries = "[]";
            model.StatisticWay = StatisticWay.逐时能耗;

            if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForOneBuilding(model);
            }
            else if (model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForOneBuilding(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForOneBuilding(model);
            }

            //QueryService.QueryByHour(model, id);

            return View(model);
        }


        [HttpPost]
        public ActionResult BuildingsOld(QueryModel model)
        {
            #region Binding Dictionary Helpers and dropdown list
            GenerateBuildingTreeModel();
            GenerateEnergyTypeTreeModel();
            #endregion


            if (model.StatisticWay == StatisticWay.逐日能耗)
            {
                QueryService.QueryByDayForOneBuilding(model);
            }
            else if (model.StatisticWay == StatisticWay.逐时能耗)
            {
                QueryService.QueryByHourForOneBuilding(model);
            }
            else if (model.StatisticWay == StatisticWay.逐月能耗)
            {
                QueryService.QueryByMonthForOneBuilding(model);
            }

            return View(model);
        }
        #endregion

        #region helper

        private void GenerateBuildingTreeModel()
        {
            //建筑字典
            List<ZTreeModel> BuildingNodes = new List<ZTreeModel>();
            foreach (var buildType in edmDb.BuildTypeInits)
            {
                BuildingNodes.Add(new ZTreeModel() { id = buildType.contain, name = buildType.typename, nocheck = "true", pId = buildType.contain });
                var childrens = edmDb.T_BD_BuildBaseInfo.Where(s => s.F_BuildID.Contains(buildType.contain));
                foreach (var builditem in childrens)
                {
                    BuildingNodes.Add(new ZTreeModel() { id = builditem.F_BuildID, name = builditem.F_BuildName, pId = buildType.contain });
                }
            }
            ViewData["BuildingNodes"] = JsonConvert.SerializeObject(BuildingNodes);
        }
        private void GenerateEnergyTypeTreeModel()
        {
            // 能耗字典
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
        }

        private void GenerateRoomTree()
        {
            //房间下拉框
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
        }



        #endregion


    }
}