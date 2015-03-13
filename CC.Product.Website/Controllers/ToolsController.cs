using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.Product.Domain.Services;

namespace CC.Product.Website.Controllers
{
    public class ToolsController : Controller
    {

         public IWayBookService WayBookService { get; set; }

         public ToolsController(IWayBookService wayBookService)
        {
            WayBookService = wayBookService;
        }

        // GET: Tools
        public ActionResult TimeLine()
        {
            return View();
        }
        public ActionResult ColPicker()
        {
            return View();
        }
        public ActionResult WayBook(string busId)
        {
           // var stationsInfo = WayBookService.GetStations(busId);
            //return View(stationsInfo.result);
            return View();

        }

        public ActionResult GetDistance()
        {
            //var longitude1 =117.052313;
            //var latitude1 = 36.704258;
            var latitude1 = 36.660980599837;
            var longitude1 =117.01942515473;
            var longitude2 = 117.22568448406;
            var latitude2 = 36.6803114297;
            var distance = GetDistance(latitude1, longitude1, latitude2, longitude2);
            return Content(distance.ToString());
        }

        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }


    }
}