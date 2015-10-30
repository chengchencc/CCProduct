using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UwpDemo.Models.WayBook;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model.  The property names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs. If using this model, you might improve app 
// responsiveness by initiating the data loading task in the code behind for App.xaml when the app 
// is first launched.

namespace UwpDemo.Models.WayBook
{
    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class RecentlySearchedBusLines
    {
        public RecentlySearchedBusLines()
        {
            this.RecentlyBusLines = new ObservableCollection<StationInfo>();
        }
        public ObservableCollection<StationInfo> RecentlyBusLines { get; private set; }

        public override string ToString()
        {
            //return JsonConvert.SerializeObject(this);
            return string.Empty;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class RecentlySearchedBusLinesSource
    {
        private static RecentlySearchedBusLinesSource _recentlySearchedBusLinesSource = new RecentlySearchedBusLinesSource();

        private RecentlySearchedBusLines _all = new RecentlySearchedBusLines();
        private static Uri dataUri = new Uri("ms-appx:///DataModel/RecentlySearchedBusLines.json");

        public RecentlySearchedBusLines All
        {
            get { return this._all; }
            set { _all = value; }
        }

        public static async Task<RecentlySearchedBusLines> GetAllAsync()
        {
            await _recentlySearchedBusLinesSource.GetDataAsync();

            return _recentlySearchedBusLinesSource.All;
        }

        public static async Task<StationInfo> GetItemAsync(string BusId)
        {
            await _recentlySearchedBusLinesSource.GetDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _recentlySearchedBusLinesSource.All.RecentlyBusLines.Where(s => s.id.Equals(BusId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetDataAsync()
        {
            if (this._all.RecentlyBusLines.Count != 0)
                return;


            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);

            this.All = null;//JsonConvert.DeserializeObject<RecentlySearchedBusLines>(jsonText);

        }

        public static async Task SaveDataAsync()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            var data = _recentlySearchedBusLinesSource.All.ToString();
            await FileIO.WriteTextAsync(file, data);
            //_recentlySearchedBusLinesSource._all = new RecentlySearchedBusLines();
        }

        public static void AddStationInfo(StationInfo stationInfo)
        {
           // await Task.Factory.StartNew(() =>
           //{
           //    _recentlySearchedBusLinesSource.All.RecentlyBusLines.Add(stationInfo);
           //});
            var existed = _recentlySearchedBusLinesSource.All.RecentlyBusLines.SingleOrDefault(s => s.id == stationInfo.id);
            if (existed!=null)
            {
                _recentlySearchedBusLinesSource.All.RecentlyBusLines.Remove(existed);
            }
            _recentlySearchedBusLinesSource.All.RecentlyBusLines.Add(stationInfo);
        }

    }

}