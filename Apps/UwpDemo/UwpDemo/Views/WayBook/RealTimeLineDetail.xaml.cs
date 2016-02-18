using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UwpDemo.Models.WayBook;
using UwpDemo.Utilities;
using WayBook.Services;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpDemo.Views.WayBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RealTimeLineDetail : BackButtonPage
    {
        public WayBookMainPageViewModel ViewModel { get; set; }
        CCHttpClient httpClient;
        List<Station> _stations;
        int _lineCount = 5;
        double _mainContentMarginLeft = 20;
        double _mainContentMarginRight = 50;
        public Double ScreenWidth
        {
            get { return Window.Current.Bounds.Width; }
        }

        public Double MainMarginLeftAndRight
        {
            get { return _mainContentMarginLeft + _mainContentMarginRight; }
        }
        public Double UnitWidth
        {
            get { return (ScreenWidth - MainMarginLeftAndRight - 30) / (_lineCount - 1); }
        }
        public RealTimeLineDetail()
        {
            this.InitializeComponent();

            ViewModel = new WayBookMainPageViewModel();

            httpClient = new CCHttpClient();
            //AutoRefreshBusPoint();

        }

        private void AutoRefreshBusPoint()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Tick += async (s, e) =>
            {
                if (ViewModel.StationInfo != null && !string.IsNullOrEmpty(ViewModel.StationInfo.id))
                {
                    RefreshBusProgressBar.Visibility = Visibility.Visible;
                    await GetBusPoint();
                }

            };
            timer.Start();
        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ViewModel.StationInfo = (StationInfo)e.Parameter;

            if (ViewModel.StationInfo != null)
            {
                _stations = ViewModel.StationInfo.stations;
            }
            GenerateStation();
            RefreshBusProgressBar.Visibility = Visibility.Visible;
            await GetBusPoint();
        }

        private void GenerateStation()
        {
            StationMap.Children.Clear();

            // var marginTop = 40;
            for (int i = 0; i < _stations.Count; i++)
            {
                var gridIndex = i / _lineCount;
                if (i % _lineCount == 0)//新行第一个节点，要生成横线跟竖线
                {
                    #region 生成横线
                    Border horizontalLine = new Border();
                    horizontalLine.Background = new SolidColorBrush(Colors.OrangeRed);
                    horizontalLine.BorderThickness = new Thickness(0);
                    if (i + _lineCount > _stations.Count)
                    {
                        //只有最后一行多于一个元素才会生成横线
                        if (_stations.Count % _lineCount - 1 > 0)
                        {
                            horizontalLine.Width = (_stations.Count % _lineCount - 1) * UnitWidth - 10;
                        }

                    }
                    else
                    {
                        horizontalLine.Width = ScreenWidth - 30 - MainMarginLeftAndRight;
                    }
                    horizontalLine.Height = 4;
                    horizontalLine.Margin = new Thickness(_mainContentMarginLeft, 25 + gridIndex * UnitWidth, _mainContentMarginRight, 0);
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
                    if (i + _lineCount < _stations.Count)
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
                var station = _stations[i];
                #region Generate station node
                StackPanel sp = new StackPanel();
                if (i / _lineCount % 2 == 0)
                {
                    sp.Margin = new Thickness((i % _lineCount) * UnitWidth, gridIndex * UnitWidth, 0, 0);
                }
                else
                {
                    sp.Margin = new Thickness(((_lineCount - 1) - (i % _lineCount)) * UnitWidth, gridIndex * UnitWidth, 0, 0);
                }
                sp.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
                sp.RenderTransformOrigin = new Point(0.5, 0.5);
                Canvas.SetZIndex(sp, 10);

                #region 生成站点名称
                TextBlock tb = new TextBlock();
                tb.FontSize = 12;
                tb.Height = 15;
                tb.Width = 90;
                tb.TextTrimming = TextTrimming.WordEllipsis;
                tb.Text = station.stationName;
                tb.Foreground = new SolidColorBrush(Colors.Black);
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
                else if (i == _stations.Count - 1)
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

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshBusProgressBar.Visibility = Visibility.Visible;

            await GetBusPoint();
        }

        private async Task GetBusPoint()
        {
            try
            {
                LastRefreshTime.Text = DateTime.Now.ToString("HH:mm:ss");

                var url = UrlServices.Instance.GetRealtimeBusesUrl(ViewModel.StationInfo.id);

                var responseJson = await httpClient.GetString(url);

                if (string.IsNullOrEmpty(responseJson))
                {
                    return;
                }

                var resultModel = JsonConvert.DeserializeObject<WayBookBase<List<RealTimeBus>>>(responseJson);

                if (resultModel.status.code != 0)
                {
                    return;
                }

                var error = await TransformCoordinate(resultModel);

                if (!string.IsNullOrEmpty(error))
                {
                    //Notification(error);
                }

                GenerateBusPoint(resultModel);
               // RefreshBusProgressBar.Visibility = Visibility.Collapsed;
            }
            catch (HttpRequestException)
            {
                MessageDialog dialog = new MessageDialog("无法连接到网络！请联网后重试！");
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                //RefreshBusProgressBar.Visibility = Visibility.Collapsed;

                //throw;
            }
            finally{
                RefreshBusProgressBar.Visibility = Visibility.Collapsed;
            }
        }


        private async Task<string> TransformCoordinate(WayBookBase<List<RealTimeBus>> buses)
        {
            var coords = string.Empty;
            foreach (var item in buses.result)
            {
                coords += item.lng + "," + item.lat + ";";
            }
            coords = coords.TrimEnd(';');

            var url = "http://api.map.baidu.com/geoconv/v1/?coords=" + coords + "&from=1&to=5&ak=075c51e0ecb472c3e2fa7b696e1fb01a";

            string responseJson = await RequestHttpString(url);

            if (string.IsNullOrEmpty(responseJson))
            {
                return "网络连接失败，请检查网络连接！";
            }
            try
            {
                JsonObject jsonObject = JsonObject.Parse(responseJson);
                JsonArray jsonArray = jsonObject["result"].GetArray();

                for (int i = 0; i < jsonArray.Count; i++)
                {
                    JsonObject groupObject = jsonArray[i].GetObject();
                    buses.result[i].lng = groupObject["x"].GetNumber();
                    buses.result[i].lat = groupObject["y"].GetNumber();
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return "返回数据格式错误";
            }
        }

        private async Task<string> RequestHttpString(string url)
        {
            var responseJson = string.Empty;

            try
            {
                responseJson = await httpClient.GetString(url);
            }
            catch (HttpRequestException)
            {
                MessageDialog dialog = new MessageDialog("无法连接到网络！请联网后重试！");
                await dialog.ShowAsync();
            }
            catch (Exception)
            {

            }

            return responseJson;
        }

        private void GenerateBusPoint(WayBookBase<List<RealTimeBus>> buses)
        {
            busContent.Children.Clear();

            foreach (var item in buses.result)
            {

                if (_stations.Count * 2 == item.dualSerialNum)
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

                image.Tag = item;

                if (item.stationSeqNum == 0 || item.stationSeqNum == 1)
                {
                    continue;
                }
                var position = item.stationSeqNum - 1;
                var preStation = _stations[position - 1];
                var nextStation = _stations[position];
                var stationDistance = GetDistance(preStation.lat, preStation.lng, nextStation.lat, nextStation.lng);
                var busNextStationDistance = GetDistance(nextStation.lat, nextStation.lng, item.lat, item.lng);

                var lineIndex = position / _lineCount;

                if (busNextStationDistance > stationDistance)
                {//加入到下一站的距离还大于两站距离 默认给他赋值为两站距离
                    busNextStationDistance = stationDistance;
                }
                var distance = busNextStationDistance / stationDistance * UnitWidth;

                if (position / _lineCount % 2 == 0)
                {
                    if (position % _lineCount == 0)
                    {
                        image.Margin = new Thickness((position % _lineCount) * UnitWidth,
                                lineIndex * UnitWidth - distance,
                                0,
                                0);
                    }
                    else
                    {
                        image.Margin = new Thickness((position % _lineCount) * UnitWidth - distance,
                                lineIndex * UnitWidth,
                                0,
                                0);
                    }


                }
                else
                {
                    if (position % _lineCount == 0)
                    {

                        image.Margin = new Thickness(((_lineCount - 1) - (position % _lineCount)) * UnitWidth,
                            lineIndex * UnitWidth - distance,
                            0,
                            0);
                    }
                    else
                    {
                        image.Margin = new Thickness(((_lineCount - 1) - (position % _lineCount)) * UnitWidth + distance,
                            lineIndex * UnitWidth,
                            0,
                            0);
                    }
                }
                image.Tapped += Image_Tapped;
                busContent.Children.Add(image);
            }
        }

        private async void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var Image = (Image)sender;
            var busInfo = (RealTimeBus)Image.Tag;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "车辆信息",
                Content = "车牌号：" + busInfo.cardId + "  归属：" + busInfo.orgName + "  危险等级：" + busInfo.velocity,
                PrimaryButtonText = "Ok"
            };
            await dialog.ShowAsync();
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
