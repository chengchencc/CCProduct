using App1.Api;
using App1.Common;
using App1.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Common.Model;
using Windows.UI.Popups;
using CC.Product.TallyBook.Common;
using Windows.Web.Http;
using System.Threading;
using Windows.Storage.Streams;
using System.Threading.Tasks;

// The Pivot Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace App1
{
    public sealed partial class PivotPage : Page
    {
        private const string FirstGroupName = "FirstGroup";
        private const string SecondGroupName = "SecondGroup";

        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");
        private HttpClient httpClient;

        public PivotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            httpClient = new HttpClient();

            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
            ApplicationView.GetForCurrentView().VisibleBoundsChanged += PivotPage_VisibleBoundsChanged;
        }

        void PivotPage_VisibleBoundsChanged(ApplicationView sender, object args)
        {
            ReportVisibleBounds();
        }

        private void ReportVisibleBounds()
        {
            
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
        /// session. The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-1");
            this.DefaultViewModel[FirstGroupName] = sampleDataGroup;

        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache. Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/>.</param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }

        /// <summary>
        /// Adds an item to the list when the app bar button is clicked.
        /// </summary>
        private async void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem dialog = new AddItem();

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //var localDBPath = "db.sdf";
                //var conn = new SQLiteAsyncConnection(localDBPath);
                var all = await DbContext.GetInstance().Conn.Table<Recorder>().OrderByDescending(s=>s.HappenDate).ToListAsync();
                recorder.ItemsSource = all;

            }
            else if(result == ContentDialogResult.Secondary)
            {

            }
            //string groupName = this.pivot.SelectedIndex == 0 ? FirstGroupName : SecondGroupName;
            //var group = this.DefaultViewModel[groupName] as SampleDataGroup;
            //var nextItemId = group.Items.Count + 1;
            //var newItem = new SampleDataItem(
            //    string.Format(CultureInfo.InvariantCulture, "Group-{0}-Item-{1}", this.pivot.SelectedIndex + 1, nextItemId),
            //    string.Format(CultureInfo.CurrentCulture, this.resourceLoader.GetString("NewItemTitle"), nextItemId),
            //    string.Empty,
            //    string.Empty,
            //    this.resourceLoader.GetString("NewItemDescription"),
            //    string.Empty);

            //group.Items.Add(newItem);

            //// Scroll the new item into view.
            //var container = this.pivot.ContainerFromIndex(this.pivot.SelectedIndex) as ContentControl;
            //var listView = container.ContentTemplateRoot as ListView;
            //listView.ScrollIntoView(newItem, ScrollIntoViewAlignment.Leading);
        }

        /// <summary>
        /// Invoked when an item within a section is clicked.
        /// </summary>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((Recorder)e.ClickedItem).Id;
            if (!Frame.Navigate(typeof(ItemPage), itemId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        /// <summary>
        /// Loads the content for the second pivot item when it is scrolled into view.
        /// </summary>
        private async void SecondPivot_Loaded(object sender, RoutedEventArgs e)
        {
            //var localDBPath = "db.sdf";
            //var conn = new SQLiteAsyncConnection(localDBPath);
            await BindingSecondPivotData();
            //var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-2");
            //this.DefaultViewModel[SecondGroupName] = all;//sampleDataGroup;
        }

        private async System.Threading.Tasks.Task BindingSecondPivotData()
        {
            var all = await DbContext.GetInstance().Conn.Table<Recorder>().OrderByDescending(s => s.HappenDate).ToListAsync();
            recorder.ItemsSource = all;
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


        #region 列表事件
        bool isElectricTorchOpen = false;
        ElectricTorch electricTorch = new ElectricTorch();
        private void ListViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (isElectricTorchOpen)
            {
                electricTorch.CloseTorch();
                electricTorch.CleanupCaptureAsync();
                ElectricTorchState.Text = "关";

            }
            else
            {
                electricTorch.CreateCaptureAsync().Wait();
                electricTorch.OpenTorch();
                ElectricTorchState.Text = "开";

            }
        }

        private void ListViewItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            if (BackgroundMediaPlayer.IsMediaPlaying())
            {
                BackgroundMediaPlayer.Shutdown();                
            }
            //Capture capture = new Capture();
            //capture.InitailizeCapture().Wait();
            //capture.PhotoCaptureForCurrent();
        }
        #endregion

        #region 小工具事件
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var progressIndicator = StatusBar.GetForCurrentView().ProgressIndicator;
            progressIndicator.Text = "加载中";
            await progressIndicator.ShowAsync();
        }

        private async void btnCloseLoading_Click(object sender, RoutedEventArgs e)
        {
            var progressIndicator = StatusBar.GetForCurrentView().ProgressIndicator;
            progressIndicator.Text = "加载中";
            await progressIndicator.HideAsync();
        }

        private void btnSetStatusBarRed_Click(object sender, RoutedEventArgs e)
        {
            StatusBar.GetForCurrentView().BackgroundColor = Colors.Red;
            StatusBar.GetForCurrentView().BackgroundOpacity = 1;
        }

        private void btnSetStatusBarDefault_Click(object sender, RoutedEventArgs e)
        {
            StatusBar.GetForCurrentView().BackgroundColor = Colors.Black;
            StatusBar.GetForCurrentView().BackgroundOpacity = 0;
        }

        private async void btnShowStatusBar_Click(object sender, RoutedEventArgs e)
        {
            await StatusBar.GetForCurrentView().ShowAsync();
        }

        private async void btnHideStatusBar_Click(object sender, RoutedEventArgs e)
        {
            await StatusBar.GetForCurrentView().HideAsync();
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);

        }

        private async void DropDbBtn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await DbContext.Instance.Conn.DropTableAsync<Recorder>();
            await DbContext.Instance.Conn.DropTableAsync<RecorderItem>();
            await DbContext.Instance.Conn.CreateTablesAsync<Recorder,RecorderItem>();

            MessageDialog dialog = new MessageDialog("删除表成功！");
            await dialog.ShowAsync();
            
        }

        private void LightSensorDemo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            if (!Frame.Navigate(typeof(LightSensorPage)))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }
        #endregion


        //private async void recorder_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        //{
        //    MessageDialog dialog = new MessageDialog("DragItemsStarting！");
        //    await dialog.ShowAsync();
        //}

        //private async void recorder_RightTapped(object sender, RightTappedRoutedEventArgs e)
        //{
        //    MessageDialog dialog = new MessageDialog("recorder_RightTapped！");
        //    await dialog.ShowAsync();
        //}

        int holdingId = -1;
        private void StackPanel_Holding(object sender, HoldingRoutedEventArgs e)
        {
            holdingId = ((Recorder)((Windows.UI.Xaml.FrameworkElement)(sender)).DataContext).Id;

            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }

        private async void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            var item = await DbContext.Instance.Conn.FindAsync<Recorder>(holdingId);//.QueryAsync<RecorderItem>("select * from RecorderItem where CreatedDate = ? ", holdingId);
            await DbContext.Instance.Conn.DeleteAsync(item);
            await DbContext.Instance.Conn.ExecuteAsync("delete from RecorderItem where RecorderId='?'",holdingId);
            await BindingSecondPivotData();
            holdingId = -1;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((sender as Pivot).SelectedIndex)
            { 
                case 0:
                    commandBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    break;
                default:
                    commandBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    break;
            }
        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private async void UploadDb_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://chaphets.chinacloudapp.cn/upload/index";
            //string url = "http://localhost:2015/upload/index";
            Uri resourceAddress;
            DbContext.Instance.Conn.CloseAsync().Wait();
            //string filePath = "/Assets/Data/RSSDataSource1.json";
            var fileDb = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync("db.sdf");
            IRandomAccessStreamWithContentType randomStream = await fileDb.OpenReadAsync();
            var streamDb = randomStream.AsStream();
            // The value of 'AddressField' is set by the user and is therefore untrusted input. If we can't create a
            // valid, absolute URI, we'll notify the user about the incorrect input.
            if (!Helpers.TryGetUri(url, out resourceAddress))
            {
                await ShowNotifyBox("Invalid URI.");
                return;
            }

            await ShowNotifyBox("In progress");
            
            try
            {
                //Stream stream = await UploadStorage.ConvertTempFileToStream("RSSDataSource");
                //Stream stream = await UploadStorage.ConvertStaticFileToStream(filePath);
                if (streamDb == null)
                {
                    await ShowNotifyBox("此文件为空，或者无此文件！");
                }
                HttpStreamContent streamContent = new HttpStreamContent(streamDb.AsInputStream());

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, resourceAddress);
                request.Content = streamContent;

                // Do an asynchronous POST.
                CancellationTokenSource cts = new CancellationTokenSource();
                //IProgress<HttpProgress> progress = new Progress<HttpProgress>(ProgressHandler);
                HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask(cts.Token);
                //HttpResponseMessage response = await httpClient.PostAsync(resourceAddress, streamContent).AsTask(cts.Token,progress);//.SendRequestAsync(request).AsTask(cts.Token);


                await ShowNotifyBox("Completed");

                //rootPage.NotifyUser("Completed", NotifyType.StatusMessage);
            }
            catch (TaskCanceledException)
            {
                //rootPage.NotifyUser("Request canceled.", NotifyType.ErrorMessage);
                ShowNotifyBox("Request canceled.").Wait();
            }
            catch (Exception ex)
            {
                //rootPage.NotifyUser("Error: " + ex.Message, NotifyType.ErrorMessage);
                 ShowNotifyBox("Error:"+ex.Message).Wait();
            }
            finally
            {
                //RequestProgressBar.Value = 100;
                DbContext.Instance.CreateConnection();
            }
        }

        private static async System.Threading.Tasks.Task ShowNotifyBox(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

    }
    internal static class Helpers
    {
        internal static bool TryGetUri(string uriString, out Uri uri)
        {
            // Note that this app has both "Internet (Client)" and "Home and Work Networking" capabilities set,
            // since the user may provide URIs for servers located on the internet or intranet. If apps only
            // communicate with servers on the internet, only the "Internet (Client)" capability should be set.
            // Similarly if an app is only intended to communicate on the intranet, only the "Home and Work
            // Networking" capability should be set.
            if (!Uri.TryCreate(uriString.Trim(), UriKind.Absolute, out uri))
            {
                return false;
            }

            if (uri.Scheme != "http" && uri.Scheme != "https")
            {
                return false;
            }

            return true;
        }

    }

}
