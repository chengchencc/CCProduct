using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayBook.Common;
using WayBook.DataModel;
using Windows.Data.Json;

namespace WayBook.Services
{
    class BusService
    {
        public async Task<WayBookBase<List<RealTimeBus>>> GetRealTimeBuses(string busId,Windows.UI.Xaml.Controls.StackPanel NotificationPanel)
        {
            var url1 = "http://60.216.101.229/server-ue2/rest/buses/busline/370100/" + busId;
            var jsonResult = await RestfulClient.Get<WayBookBase<List<RealTimeBus>>>(url1);
            if (jsonResult.State != RestfulResultState.Success)
            {
                
                Utilities.ShowNotification(NotificationPanel, "网络连接失败，请检查网络连接！");

                //Utilities.ShowMessage("网络连接失败，请检查网络连接！");
                return null;
            }

            var buses = jsonResult.Model;

           var result =  await TransformCoordinate(buses,NotificationPanel);
           if (result == RestfulResultState.Success)
           {
               return buses;
           }
           else
           {
               return null;
           }
        }

        private static async Task<RestfulResultState> TransformCoordinate(WayBookBase<List<RealTimeBus>> buses, Windows.UI.Xaml.Controls.StackPanel NotificationPanel)
        {
            var coords = string.Empty;
            foreach (var item in buses.result)
            {
                coords += item.lng + "," + item.lat + ";";
            }
            coords = coords.TrimEnd(';');

            var url = "http://api.map.baidu.com/geoconv/v1/?coords=" + coords + "&from=1&to=5&ak=075c51e0ecb472c3e2fa7b696e1fb01a";

            //var baiduMapCoords = await HttpClientWapper.Instance.Get(url);
            var baiduMapCoords = await RestfulClient.Get(url);
            if (string.IsNullOrEmpty(baiduMapCoords))
            {
                Utilities.ShowNotification(NotificationPanel, "网络连接失败，请检查网络连接！");
                //Utilities.ShowMessage("网络连接失败，请检查网络连接！");
                return RestfulResultState.EmptyResponseData;
            }
            try
            {
                JsonObject jsonObject = JsonObject.Parse(baiduMapCoords);
                JsonArray jsonArray = jsonObject["result"].GetArray();

                for (int i = 0; i < jsonArray.Count; i++)
                {
                    JsonObject groupObject = jsonArray[i].GetObject();
                    buses.result[i].lng = groupObject["x"].GetNumber();
                    buses.result[i].lat = groupObject["y"].GetNumber();
                }
                return RestfulResultState.Success;
            }catch(Exception){
                return RestfulResultState.ResponseDataError;
            }
        }



        //internal Task<object> GetRealTimeBuses(string _busId, Windows.UI.Xaml.Controls.StackPanel NotificationPanel)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
