using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpDemo.Views.BaiduYun
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VideoPage : Page
    {
        ObservableCollection<Info> Images;
        HttpClient httpClient;
        public VideoPage()
        {
            Images = new ObservableCollection<Info>();
            this.InitializeComponent();
            httpClient = new HttpClient();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var param  = (MainListModel)e.Parameter;
            title.Text = param.Name;
          await  GetBaiduYunContent();

        }

        private async Task GetBaiduYunContent()
        {
            String url = "http://pan.baidu.com";
            HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));
            String result = await response.Content.ReadAsStringAsync();


            //http://pan.baidu.com/api/categorylist?channel=chunlei&clienttype=0&web=1&num=100&page=1&dir=%2F&order=time&desc=1&showempty=0&category=1&_=1448845987426&bdstoken=889b54494be7a10d93f8578876f6702d&channel=chunlei&clienttype=0&web=1&app_id=250528

            var tokenRegex = "yunData.MYBDSTOKEN.*=.*?\"?\"(.*)?\"";

            var bdstoken = GetRegexValue(tokenRegex, result);
            var channel = "chunlei";
            var clienttype = "0";
            var web = "1";
            var num = 30;
            var dir = "%2F";
            var order = "time";
            var category = "1";//1 视频 3 图片
            var appid = "250528";
            var desc = "1";
            var page = 1;
            var categoryUrl = string.Format("http://pan.baidu.com/api/categorylist?" +
                 "channel=chunlei&clienttype={0}&web=1&num={1}&page={2}&dir={3}&order={4}" +
                 "&showempty=0&category={5}&_={6}&bdstoken={7}&app_id={8}&desc={9}",
                 clienttype, num, page, dir, order, category, GetTimeSpan(), bdstoken, appid,desc
                 );

            var categoryResult = await httpClient.GetStringAsync(categoryUrl);
            if (!string.IsNullOrEmpty(categoryResult))
            {
                var categoryList = JsonConvert.DeserializeObject<Category>(categoryResult);
                foreach (var item in categoryList.info)
                {
                    Images.Add(item);
                }
            }
        }


        #region Helper
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

        #endregion

        private void VideoList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Info)e.ClickedItem;
            
        }
    }




}
