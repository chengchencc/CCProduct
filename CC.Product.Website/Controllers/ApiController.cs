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
        // GET: Api
        public ActionResult WayBookRealTimeBusInfo(string busName)
        {
            Bus bus = GetBusIdByName(busName); //WayBookService.GetBusIdByName("115");

            return View(bus.result.result);
        }


        public Bus GetBusIdByName(string busName)
        {
            RestfulClient httpClient = new RestfulClient();
            var response = httpClient.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/" + busName + "/0/20");
            var buses = WayBookService.GetBusIdByName(busName);
            //var buses = JsonConvert.DeserializeObject<Bus>(response);

            return buses;
        }


    }
}