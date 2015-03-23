using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WayBook.DataModel;
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

namespace WayBook.Data
{
    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class RecentlySearchedBusLinesSource
    {
        public RecentlySearchedBusLinesSource()
        {
            this.RecentlyBusLines = new ObservableCollection<StationInfo>();
        }
        public ObservableCollection<StationInfo> RecentlyBusLines { get; private set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
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

        private ObservableCollection<StationInfo> _all = new ObservableCollection<StationInfo>();
        private Uri dataUri = new Uri("ms-appx:///DataModel/RecentlySearchedBusLines.json");

        public ObservableCollection<StationInfo> All
        {
            get { return this._all; }
            set { _all = value; }
        }

        public static async Task<IEnumerable<StationInfo>> GetAllAsync()
        {
            await _recentlySearchedBusLinesSource.GetDataAsync();

            return _recentlySearchedBusLinesSource.All;
        }

        public static async Task<StationInfo> GetItemAsync(string BusId)
        {
            await _recentlySearchedBusLinesSource.GetDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _recentlySearchedBusLinesSource.All.Where((group) => group.id.Equals(BusId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetDataAsync()
        {
            if (this._all.Count != 0)
                return;


            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);

           this.All =  JsonConvert.DeserializeObject<RecentlySearchedBusLinesSource>(jsonText).RecentlyBusLines;

            }

        private async Task SaveDataAsync(){
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            FileIO.WriteTextAsync(file,this.ToString());
            
        }

        }
    }
}