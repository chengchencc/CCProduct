using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDMWebsite.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            ViewData["Breadcrumbs"] = breadcrumbs;
        }

    }


}