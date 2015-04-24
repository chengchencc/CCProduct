using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace WayBook.Services
{
   public class DataServices
    {
        private ApplicationDataContainer localSettings;
        public DataServices()
        {
            localSettings = ApplicationData.Current.LocalSettings;
        }

        public static DataServices Instance
        {
            get { return new DataServices(); }
        }

        public bool Add(string settingName,object value)
        {
            if (localSettings.Values.ContainsKey(settingName))
                return false;
            else
                localSettings.Values[settingName] = value;
            return true;
        }

        public void AddOrUpdate(string settingName, object value)
        {
            localSettings.Values[settingName] = value;
        }

        public void Update(string settingName, object value)
        {
            localSettings.Values[settingName] = value;
        }

        public void Delete(string settingName, object value)
        {
            if (localSettings.Values.ContainsKey(settingName))
                localSettings.Values.Remove(settingName);
        }

        public object Get(string settingName)
        {
            return localSettings.Values[settingName];
        }

    }
}
