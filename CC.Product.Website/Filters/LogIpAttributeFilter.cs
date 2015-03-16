using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC.Product.Core;

namespace CC.Product.Website.Filters
{
    public class LogIpAttributeFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var a = filterContext.HttpContext.Request.ServerVariables;
            foreach (var item in a)
            {
                var b = a[item.ToString()];
                LogHelper.WriteInfo(item.ToString() + ":" + b);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}