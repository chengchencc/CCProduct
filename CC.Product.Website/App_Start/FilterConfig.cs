using System.Web;
using System.Web.Mvc;
using CC.Product.Website.Filters;

namespace CC.Product.Website
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            LogIpAttributeFilter logIpFilter = new LogIpAttributeFilter();
            filters.Add(logIpFilter);
        }
    }
}
