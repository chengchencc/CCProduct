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
using Windows.UI.Notifications;
using System.Threading;
using Windows.UI.Core;
using System.Threading.Tasks;
using WayBook.Services;
using Windows.UI.Xaml.Media.Imaging;

// The Hub Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace WayBook
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemPageNew : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        string _busId = string.Empty;
        List<Station> stations;
        int lineCount = 5;
        double mainContentMarginLeft = 20;
        double mainContentMarginRight = 50;
        
        public ItemPageNew()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Disabled;

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

        public Double ScreenWidth
        {
            get { return Window.Current.Bounds.Width; }
        }

        public Double MainMarginLeftAndRight
        {
            get { return mainContentMarginLeft + mainContentMarginRight; }
        }

        public Double UnitWidth
        {
            get { return (ScreenWidth - MainMarginLeftAndRight - 30) / (lineCount - 1); }
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
            //ToastNotification toast = new ToastNotification();

            var stationInfo = e.NavigationParameter as StationInfo;
            if (stationInfo != null)
            {
                stations = stationInfo.stations;
                this.DefaultViewModel["Item"] = stationInfo;
                _busId = stationInfo.id;
            }
            else
            {
                var item = (ResultItem)e.NavigationParameter;
                //this.DefaultViewModel["Item"] = item;
                _busId = item.id;
                var url = UrlServices.Instance.GetStationsUrl(_busId);
                var jsonResult = await RestfulClient.Get(url);
                //var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buslines/370100/" + item.id);
                //var jsonResult = await RestfulClient.Get("http://60.216.101.229/server-ue2/rest/buslines/370100/" + item.id);
                if (string.IsNullOrEmpty(jsonResult.Content))
                {
                    // Utilities.ShowMessage("网络连接失败，请检查网络连接！");
                    Utilities.ShowNotification(NotificationPanel, "网络连接失败，请检查网络连接！");
                    return;
                }

                var stationsInfo = JsonConvert.DeserializeObject<WayBookBase<StationInfo>>(jsonResult.Content);
                if (stationsInfo == null)
                {
                    return;
                }
                stations = stationsInfo.result.stations;
                this.DefaultViewModel["Item"] = stationsInfo.result;
                //保存最近搜索
                RecentlySearchedBusLinesSource.AddStationInfo(stationsInfo.result);
                await RecentlySearchedBusLinesSource.SaveDataAsync();
            }
            GenerateStation();

            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                while (true)
                {
                    var canGet = await GetBusPoint();
                    if (!canGet)
                    {
                        break;
                    }

                    await Task.Delay(10000);
                }
            });


        }

        private void GenerateStation()
        {
            StationMap.Children.Clear();

            // var marginTop = 40;
            for (int i = 0; i < stations.Count; i++)
            {
                var gridIndex = i / lineCount;
                if (i % lineCount == 0)//新行第一个节点，要生成横线跟竖线
                {
                    #region 生成横线
                    Border horizontalLine = new Border();
                    horizontalLine.Background = new SolidColorBrush(Colors.OrangeRed);
                    horizontalLine.BorderThickness = new Thickness(0);
                    if (i + lineCount > stations.Count)
                    {
                        //只有最后一行多于一个元素才会生成横线
                        if (stations.Count % lineCount - 1 > 0)
                        {
                            horizontalLine.Width = (stations.Count % lineCount - 1) * UnitWidth - 10;
                        }

                    }
                    else
                    {
                        horizontalLine.Width = ScreenWidth - 30 - MainMarginLeftAndRight;
                    }
                    horizontalLine.Height = 4;
                    horizontalLine.Margin = new Thickness(mainContentMarginLeft, 25 + gridIndex * UnitWidth, mainContentMarginRight, 0);
                    horizontalLine.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                    if (gridIndex % 2 == 0)
                    {
                        horizontalLine.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                    }
                    else
                    {
                        horizontalLine.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
                    }
                    StationMap.Children.Add(horizontalLine);

                    #endregion
                    #region 生成竖线
                    if (i + lineCount < stations.Count)
                    {

                        Border verticalLine = new Border();
                        verticalLine.Background = new SolidColorBrush(Colors.OrangeRed);
                        verticalLine.BorderThickness = new Thickness(0);
                        verticalLine.Height = UnitWidth;
                        verticalLine.Width = 4;
                        if (gridIndex % 2 == 0)
                        {
                            verticalLine.Margin = new Thickness(ScreenWidth - MainMarginLeftAndRight - (30 / 2 + 2), gridIndex * UnitWidth + 28, 0, 0);
                        }
                        else
                        {
                            verticalLine.Margin = new Thickness(14, gridIndex * UnitWidth + 28, 0, 0);
                        }

                        verticalLine.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                        verticalLine.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                        StationMap.Children.Add(verticalLine);
                    }
                    #endregion
                }
                var station = stations[i];
                #region Generate station node
                StackPanel sp = new StackPanel();
                if (i / lineCount % 2 == 0)
                {
                    sp.Margin = new Thickness((i % lineCount) * UnitWidth, gridIndex * UnitWidth, 0, 0);
                }
                else
                {
                    sp.Margin = new Thickness(((lineCount - 1) - (i % lineCount)) * UnitWidth, gridIndex * UnitWidth, 0, 0);
                }
                sp.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                sp.RenderTransformOrigin = new Point(0.5, 0.5);
                Canvas.SetZIndex(sp, 10);

                #region 生成站点名称
                TextBlock tb = new TextBlock();
                tb.Height = 15;
                tb.Width = 90;
                tb.TextTrimming = TextTrimming.WordEllipsis;
                tb.Text = station.stationName;
                var tbTransform = new CompositeTransform();
                tbTransform.TranslateX = 20;
                tbTransform.TranslateY = -8;
                tbTransform.Rotation = -25;
                tb.RenderTransform = tbTransform;
                sp.Children.Add(tb);
                #endregion
                #region 生成站点图片
                Image image = new Image();
                if (i == 0)
                {
                    image.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/sketch_start.png"));
                    image.Margin = new Thickness(0, -8, 0, 0);
                    image.Width = 40;
                    image.Height = 40;
                }
                else if (i == stations.Count - 1)
                {
                    image.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/sketch_finish.png"));
                    image.Margin = new Thickness(0, -8, 0, 0);
                    image.Width = 40;
                    image.Height = 40;
                }
                else
                {
                    image.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/staitonlist_station_noline.png"));
                    image.Margin = new Thickness(0, -2, 0, 0);
                    image.Width = 30;
                    image.Height = 30;
                }

                image.Stretch = Stretch.UniformToFill;
                image.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                sp.Children.Add(image);
                #endregion

                StationMap.Children.Add(sp);
                #endregion
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


        //private async void SearchBusLineBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    await GetBusPoint();
        //}

        private async System.Threading.Tasks.Task<bool> GetBusPoint()
        {
            try
            {
                BusService busService = new BusService();
                var buses = await busService.GetRealTimeBuses(_busId, NotificationPanel);
                if (buses == null)
                {
                    return false;
                }
                #region Display
                GenerateBusPoint(buses);
                return true;
                #endregion
            }
            catch (Exception)
            {
                return false;
                //NotificationContent.Text = "网络连接失败，请检查网络连接！";
                //Utilities.ShowNotification(NotificationPanel);
                //Utilities.ShowMessage("网络连接失败，请检查网络连接！");
            }
        }

        private void GenerateBusPoint(WayBookBase<List<RealTimeBus>> buses)
        {
            busContent.Children.Clear();

            foreach (var item in buses.result)
            {

                if (stations.Count * 2 == item.dualSerialNum)
                {
                    continue;
                }
                //<Image Source="Assets/sketch_busicon.png" Width="30" Height="30" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="85,0,0,0"/>
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"ms-appx:/Assets/sketch_busicon.png"));
                image.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                image.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                image.Width = 30;
                image.Height = 30;


                if (item.stationSeqNum == 0)
                {
                    continue;
                }
                var position = item.stationSeqNum-1;
                var preStation = stations[position - 1];
                var nextStation = stations[position];
                var stationDistance = GetDistance(preStation.lat, preStation.lng, nextStation.lat, nextStation.lng);
                var busNextStationDistance = GetDistance(nextStation.lat, nextStation.lng, item.lat, item.lng);

                var lineIndex = position / lineCount;

                if (busNextStationDistance > stationDistance)
                {//加入到下一站的距离还大于两站距离 默认给他赋值为两站距离
                    busNextStationDistance = stationDistance;
                }
                var distance = busNextStationDistance / stationDistance * UnitWidth;

                if (position / lineCount % 2 == 0)
                {
                    if (position % lineCount == 0)
                    {
                        image.Margin = new Thickness((position % lineCount) * UnitWidth,
                                lineIndex * UnitWidth-distance,
                                0,
                                0);
                    }
                    else
                    {
                        image.Margin = new Thickness((position % lineCount) * UnitWidth - distance,
                                lineIndex * UnitWidth,
                                0,
                                0);
                    }


                }
                else
                {
                    if (position % lineCount == 0)
                    {

                        image.Margin = new Thickness(((lineCount - 1) - (position % lineCount)) * UnitWidth,
                            lineIndex * UnitWidth - distance,
                            0,
                            0);
                    }
                    else
                    {
                        image.Margin = new Thickness(((lineCount - 1) - (position % lineCount)) * UnitWidth +distance,
                            lineIndex * UnitWidth,
                            0,
                            0);
                    }
                }
                busContent.Children.Add(image);
            }
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
