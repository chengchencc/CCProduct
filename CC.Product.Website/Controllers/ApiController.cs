using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.Product.Core;
using CC.Product.Domain.Services;

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
            WayBookService.GetBusIdByName(busName);

            return View();
        }
    }
}