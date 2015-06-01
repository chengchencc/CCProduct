using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EDMWebsite.Models.ViewModels;
using CC.EDM.Model.RealEDMDb;
using Newtonsoft.Json;
namespace EDMWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            ViewData["Breadcrumbs"] = breadcrumbs;

            using (var edmDb = new RealEDMDbContext())
            {
                //建筑左侧列表
                List<BuildingsMenuItem> buildingsMenu = new List<BuildingsMenuItem>();
                foreach (var buildType in edmDb.BuildTypeInits.OrderBy(s=>s.typename))
                {
                    BuildingsMenuItem buildingsMenuItem = new BuildingsMenuItem();
                    buildingsMenuItem.BuildingType = buildType;
                    var childrens = edmDb.T_BD_BuildBaseInfo.Where(s => s.F_BuildID.Contains(buildType.contain));
                    buildingsMenuItem.BuildingList.AddRange(childrens);
                    buildingsMenu.Add(buildingsMenuItem);
                }
                ViewData["BuildingsMenu"] = buildingsMenu;

            }
        }

    }


}