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

        public PivotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

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
            var all = await  DbContext.GetInstance().Conn.Table<Recorder>().OrderByDescending(s=>s.HappenDate).ToListAsync();
            recorder.ItemsSource = all;
            //var sampleDataGroup = await SampleDataSource.GetGroupAsync("Group-2");
            //this.DefaultViewModel[SecondGroupName] = all;//sampleDataGroup;
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

    }
}
