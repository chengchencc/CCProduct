using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace WayBook.Common
{
    public class Utilities
    {
        public static string GetStringFromResource( string key)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
            return resourceLoader.GetString(key);
        }


    }
}
