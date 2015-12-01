using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpDemo.Views.BaiduYun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexPage : Page
    {
        HttpClient httpClient;
        HttpClientHandler httpClientHandler;
        Category ViewModel;
        ObservableCollection<Info> Images;
        public ObservableCollection<MainListModel> MainListModelViewModel;

        public IndexPage()
        {
            Images = new ObservableCollection<Info>();
            MainListModelViewModel = new ObservableCollection<MainListModel>();
            MainListModelViewModel.Add(new MainListModel() { Name = "全部", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "图片", TypeCode = "3" });
            MainListModelViewModel.Add(new MainListModel() { Name = "文档", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "视频", TypeCode = "1" });
            MainListModelViewModel.Add(new MainListModel() { Name = "种子", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "音乐", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "其他", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "我的分享", TypeCode = "0" });
            MainListModelViewModel.Add(new MainListModel() { Name = "回收站", TypeCode = "0" });

            InitialHttpClient();
            this.InitializeComponent();

            MainListView.ItemsSource = MainListModelViewModel;

            GetBaiduYunContent();
        }

        private void InitialHttpClient()
        {
            httpClientHandler = new HttpClientHandler();
            httpClient = new HttpClient(httpClientHandler);
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
        }

        private async void OpenUrlButton_Click(object sender, RoutedEventArgs e)
        {
            //var url = urlTextBox.Text;




            //var response = await httpClient.GetAsync(url);

            //var header = response.Headers;
            //var content = response.Content.ReadAsStringAsync();

            //LoginBaiduYun();

            //if (!string.IsNullOrEmpty(url))
            //{
            //    webview.Navigate(new Uri(url));
            //}

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (webview.CanGoBack)
            {
                webview.GoBack();
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (webview.CanGoForward)
            {
                webview.GoForward();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            webview.Refresh();
        }

        private async void GetDocument_Click(object sender, RoutedEventArgs e)
        {
            List<string> argu = new List<string>();
            argu.Add("document.documentElement.innerHTML");
         var result =   await webview.InvokeScriptAsync("eval",argu.ToArray());
            //  HtmlResult
            //GenerateRichDoc(result);
            //resultView.NavigateToString(result);
        }

        private void GenerateRichDoc(string text)
        {
            //// HtmlDocument
            //HtmlResult.Blocks.Clear();
            //var p = new Paragraph();
            //Run r = new Run();
            //r.Text = text;
            //p.Inlines.Add(r);
            //HtmlResult.Blocks.Add(p);
        }

        public void GetBaiduYunContent()
        {
            String url = "http://pan.baidu.com";
            HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
            String result = response.Content.ReadAsStringAsync().Result;

            if (result.Contains("登录百度帐号"))
            {
                WebLogin();
                return;
            }
            return;

            //var url = "http://pan.baidu.com/api/categorylist?channel=chunlei&clienttype=0&web=1&num=100&page=1&dir=%2F&order=time&desc=1&showempty=0&category=6&_=1447394940835&bdstoken=889b54494be7a10d93f8578876f6702d&channel=chunlei&clienttype=0&web=1&app_id=250528";

            var tokenRegex = "yunData.MYBDSTOKEN.*=.*?\"?\"(.*)?\"";

            var bdstoken = GetRegexValue(tokenRegex,result);
            var channel = "chunlei";
            var clienttype = "0";
            var web = "1";
            var num = 100;
            var dir = "%2F";
            var order = "time";
            var category = "3";
            var appid = "250528";
            var page = 1;
           var categoryUrl= string.Format("http://pan.baidu.com/api/categorylist?" +
                "channel=chunlei&clienttype={0}&web=1&num={1}&page={2}&dir={3}&order={4}" +
                "&desc=1&showempty=0&category={5}&_={6}&bdstoken={7}&app_id={8}",
                clienttype, num, page, dir, order, category, GetTimeSpan(), bdstoken, appid
                );

           var categoryResult =  httpClient.GetStringAsync(categoryUrl).Result;
            if (!string.IsNullOrEmpty(categoryResult))
            {
                var categoryList = JsonConvert.DeserializeObject<Category>(categoryResult);
                foreach (var item in categoryList.info)
                {
                    Images.Add(item);
                }
            }
        }

        private void WebLogin()
        {
            //urlTextBox.Text = "http://pan.baidu.com";

            contentGrid.Visibility = Visibility.Collapsed;
            webview.Visibility = Visibility.Visible;

            webview.Navigate(new Uri("http://pan.baidu.com"));
        }




        private string GetRegexValue(string regex, string search)
        {
            var reg = new Regex(regex);
            var result = reg.Match(search).Groups[1].Value;
            return result;
        }

        private Int64 GetTimeSpan()
        {
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var a = (DateTime.Now.Ticks - startTime.Ticks) / 1000;
            return a;

        }

        private void webview_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if(args.Uri.AbsoluteUri.Contains("/disk/home"))
            {
                webview.Visibility = Visibility.Collapsed;
                contentGrid.Visibility = Visibility.Visible;
                GetBaiduYunContent();
            }
        }

        private void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = (MainListModel)e.ClickedItem;
            if (model.TypeCode == "1")
            {
                this.Frame.Navigate(typeof(VideoPage), e.ClickedItem, new DrillInNavigationTransitionInfo());
            }
            else
            if (model.TypeCode == "3")
            {
                this.Frame.Navigate(typeof(PhotoPage), e.ClickedItem, new DrillInNavigationTransitionInfo());
            }

        }
    }

    public class MainListModel
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string TypeCode { get; set; }
        public object Attributes { get; set; }
    }
    

    public class Thumbs
    {
        public string icon { get; set; }
        public string url3 { get; set; }
        public string url2 { get; set; }
        public string url1 { get; set; }
    }

    public class Info
    {
        public int server_mtime { get; set; }
        public int category { get; set; }
        public object fs_id { get; set; }
        public int server_ctime { get; set; }
        public int isdir { get; set; }
        public Thumbs thumbs { get; set; }
        public int local_mtime { get; set; }
        public object size { get; set; }
        public string md5 { get; set; }
        public string path { get; set; }
        public int local_ctime { get; set; }
        public string object_key { get; set; }
        public string server_filename { get; set; }
    }

    public class Category
    {
        public int errno { get; set; }
        public List<Info> info { get; set; }
        public long request_id { get; set; }
    }


}
