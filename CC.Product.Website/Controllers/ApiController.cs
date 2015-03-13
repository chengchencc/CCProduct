using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.Product.Core;
using CC.Product.Domain.Services;
using CC.Product.ViewModels;
using Newtonsoft.Json;

namespace CC.Product.Website.Controllers
{
    public class ApiController : Controller
    {
        public IWayBookService WayBookService { get; set; }

        public ApiController(IWayBookService wayBookService)
        {
            WayBookService = wayBookService;
        }
        #region WayBook Api
        public ActionResult GetBusList(string busName)
        {
            Bus bus = WayBookService.GetBusIdByName(busName);

            return View(bus.result.result);
        }

        public ActionResult GetRealTimeBuses(string busId)
        {
            string realTimeBuses = WayBookService.GetRealTimeBuses(busId);
            return Content(realTimeBuses);
        }
        public ActionResult GetBusStations(string busId)
        {
            string res = WayBookService.GetStationsInJson(busId);
            return Content(res);
        }

        #endregion
    }
}