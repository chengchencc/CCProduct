using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.EDM.Domain.CommonHelpers
{
    public static class ConfigurationManagerHelper
    {
        public static string GetAppSettings(string key)
        {
            var result = System.Configuration.ConfigurationManager.AppSettings[key];
            return result;
        }
    }
}