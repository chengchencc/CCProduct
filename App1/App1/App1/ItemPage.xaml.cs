using App1.Common;
using App1.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Pivot Application template is documented at http://go.microsoft.com/fwlink/?LinkID=391641

namespace App1
{
    /// <summary>
    /// A page that displays details for a single item within a group.
    /// </summary>
    public sealed partial class ItemPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

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
            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);

            // TODO: Create an appropriate data model for your problem domain to replace the sample data.
            var itemId = ((int)e.NavigationParameter);
            //var localDBPath = "db.sdf";
            //var conn = new SQLiteAsyncConnection(localDBPath);
            //var all = await conn.Table<RecorderItem>().ToListAsync();
            var item = await DbContext.GetInstance().Conn.FindAsync<RecorderItem>(itemId);
            this.DefaultViewModel["Item"] = item;
            List<RecorderItem> aa = new List<RecorderItem>();
            aa.Add(new RecorderItem() { Id = 1, HappenDate = DateTime.Now });
            aa.Add(new RecorderItem() { Id = 1, HappenDate = DateTime.Now });
            aa.Add(new RecorderItem() { Id = 1, HappenDate = DateTime.Now });
            //PurchaseList.ItemsSource = aa;
          var content = string.Format( "{0}利润{1}元，其中收购单价：{2}元/kg，收购总重量为：{3}kg，收购花费为{4}元。卖出单价为：{5}元/kg，卖出重量为：{6}kg，卖出得{7}元。",
                item.HappenDate.ToString("yyyy年MM月dd日"), item.Income.ToString("F2"), item.PurchaseUnitPrice.ToString("F2"), item.PurchaseWeight.ToString("F2"), item.PurchaseTotalPrice.ToString("F2"), item.SellUnitPrice.ToString("F2"), item.SellWeight.ToString("F2"), item.SellTotalPrice.ToString("F2"));

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeContent dialog = new AddIncomeContent();

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //var localDBPath = "db.sdf";
                //var conn = new SQLiteAsyncConnection(localDBPath);
                //var all = await DbContext.GetInstance().Conn.Table<RecorderItem>().OrderByDescending(s => s.HappenDate).ToListAsync();
                //recorder.ItemsSource = all;

            }
            else if (result == ContentDialogResult.Secondary)
            {

            }



            //RecorderItem recorder = new RecorderItem();
            //recorder.CreatedDate = DateTime.Now;
            //var id = await DbContext.GetInstance().Conn.InsertAsync(recorder);
        }

        private async void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            //var itemId = ((RecorderItem)e.ClickedItem).Id;
            //var itemId = "id";
            //if (!Frame.Navigate(typeof(AddPurchaseItem), itemId))
            //{
            //    throw new Exception("Navigation failed.");
            //}

            AddPurchaseContent dialog = new AddPurchaseContent();

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //var localDBPath = "db.sdf";
                //var conn = new SQLiteAsyncConnection(localDBPath);
                //var all = await DbContext.GetInstance().Conn.Table<RecorderItem>().OrderByDescending(s => s.HappenDate).ToListAsync();
                //recorder.ItemsSource = all;

            }
            else if (result == ContentDialogResult.Secondary)
            {

            }
        }
    }
}