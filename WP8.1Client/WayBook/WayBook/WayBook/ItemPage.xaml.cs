using WayBook.Common;
using WayBook.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WayBook.DataModel;
using Newtonsoft.Json;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.Data.Json;

// The Hub Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace WayBook
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        string _busId = string.Empty;
        List<Station> stations;

        public ItemPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>.
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var item = await SampleDataSource.GetItemAsync((string)e.NavigationParameter);
            //this.DefaultViewModel["Item"] = item;

            var stationInfo = e.NavigationParameter as StationInfo;
            if (stationInfo != null)
            {
                stations = stationInfo.stations;
            }
            else
            {
                var item = (ResultItem)e.NavigationParameter;
                this.DefaultViewModel["Item"] = item;
                _busId = item.id;
                var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buslines/370100/" + item.id);
                var stationsInfo = JsonConvert.DeserializeObject<WayBookBase<StationInfo>>(jsonResult);
                if (stationsInfo == null)
                {
                    return;
                }
                RecentlySearchedBusLinesSource source = new RecentlySearchedBusLinesSource();
                var old = await RecentlySearchedBusLinesSource.GetAllAsync();
                source.All.Add(stationsInfo.result);
                foreach (var item1 in old.ToList())
                {
                source.All.Add(item1);
                    
                }
                await source.SaveDataAsync();
                stations = stationsInfo.result.stations;
            }
            int i = 1;
            StationPanel.Children.Clear();
            LinePanel.Children.Clear();
            foreach (var stationItem in stations)
            {
                Button b = new Button();
                b.Content = stationItem.stationName;
                b.RequestedTheme = ElementTheme.Light;
                b.BorderThickness = new Thickness(0);

                b.Margin = new Thickness(0, 100, 0, 0);
                StationPanel.Children.Add(b);

                Ellipse ellipse = new Ellipse();
                ellipse.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                ellipse.Width = 20;
                ellipse.Height = 20;
                ellipse.Fill = new SolidColorBrush(Colors.White);
                ellipse.Stroke = new SolidColorBrush(Colors.DeepSkyBlue);
                ellipse.StrokeThickness = 5;
                if (i == 1)
                {
                    ellipse.Margin = new Thickness(0, 118.75, 0, 0);
                }
                else
                {
                    ellipse.Margin = new Thickness(0, 137.5, 0, 0);
                }
                LinePanel.Children.Add(ellipse);
                i++;
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion


        private async void SearchBusLineBtn_Click(object sender, RoutedEventArgs e)
        {
            #region GetData
            var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buses/busline/370100/" + _busId);
            var buses = JsonConvert.DeserializeObject<WayBookBase<List<RealTimeBus>>>(jsonResult);
            if (buses == null)
            {
                return;
            }
            var coords = string.Empty;
            foreach (var item in buses.result)
            {
                coords += item.lng + "," + item.lat + ";";
            }
            coords = coords.TrimEnd(';');

            var url = "http://api.map.baidu.com/geoconv/v1/?coords=" + coords + "&from=1&to=5&ak=075c51e0ecb472c3e2fa7b696e1fb01a";

            var baiduMapCoords = await HttpClientWapper.Instance.Get(url);
            JsonObject jsonObject = JsonObject.Parse(baiduMapCoords);
            JsonArray jsonArray = jsonObject["result"].GetArray();

            for (int i = 0; i < jsonArray.Count; i++)
            {
                JsonObject groupObject = jsonArray[i].GetObject();
                buses.result[i].lng = groupObject["x"].GetNumber();
                buses.result[i].lat = groupObject["y"].GetNumber();
            }
            #endregion

            #region Display
            BusPanel.Children.Clear();

            foreach (var item in buses.result)
            {
                //<StackPanel Orientation="Horizontal" HorizontalAlignment="Left" VerticalAlignment="Center" Margin="-15,100,0,0">
                //         <Ellipse HorizontalAlignment="Center" Width="10" Height="10"  Fill="#FFF51717" StrokeThickness="1" />
                //         <Button Content="鲁A18556" RequestedTheme="Light" RenderTransformOrigin="0.5,0.5" BorderThickness="1" BorderBrush="#FF7C1D1D" Foreground="#FFF55353"/>
                //     </StackPanel>

                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                panel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;
                panel.Margin = new Thickness(-15, 0, 0, 0);

                Ellipse el = new Ellipse();
                el.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                el.Width = 10;
                el.Height = 10;
                el.Fill = new SolidColorBrush(Colors.OrangeRed);
                el.StrokeThickness = 1;

                Button btn = new Button();
                btn.Content = item.cardId;
                btn.RequestedTheme = ElementTheme.Light;
                btn.Background = new SolidColorBrush(Colors.WhiteSmoke);
                btn.BorderThickness = new Thickness(1);
                btn.BorderBrush = new SolidColorBrush(Colors.OrangeRed);
                btn.Foreground = new SolidColorBrush(Colors.OrangeRed);

                panel.Children.Add(el);
                panel.Children.Add(btn);

                var position = item.stationSeqNum;
                var preStation = stations[position - 1];
                var nextStation = stations[position];
                var stationDistance = GetDistance(preStation.lat, preStation.lng, nextStation.lat, nextStation.lng);
                var busNextStationDistance = GetDistance(nextStation.lat, nextStation.lng, item.lat, item.lng);
                PlaneProjection pro = new PlaneProjection();
                pro.GlobalOffsetY = position * 100 + 100 - busNextStationDistance / stationDistance * 100 + position * 57.5;
                
                panel.Projection = pro;
                BusPanel.Children.Add(panel);
            }

            #endregion
        }

        #region Helpers
        private const double EARTH_RADIUS = 6378.137;//地球半径
        private static double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLat2 = Rad(lat2);
            double a = radLat1 - radLat2;
            double b = Rad(lng1) - Rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
        #endregion

    }
}
