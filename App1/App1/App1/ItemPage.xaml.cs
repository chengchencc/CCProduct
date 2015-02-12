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
using App1.Common.Model;

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
        public int RecorderId { get; set; }
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

            // TODO: Create an appropriate data model for your problem domain to replace the sample data.
            var itemId = ((int)e.NavigationParameter);
            RecorderId = itemId;
            var recorder = await DbContext.GetInstance().Conn.FindAsync<Recorder>(itemId);

            var recorderItems = await DbContext.Instance.Conn.QueryAsync<RecorderItem>("select * from RecorderItem where RecorderId = "+RecorderId);

            recorder.TotalExpenditure = 0;
            recorder.TotalIncome = 0;
            foreach (var item in recorderItems)
            {
                recorder.TotalExpenditure += item.PurchaseTotalPrice;
                recorder.TotalIncome += item.SellTotalPrice;
            }
            recorder.Profit = recorder.TotalIncome - recorder.TotalExpenditure;
            
            IncomeContent.Text = "总收入："+recorder.TotalIncome;
            ExpenditureContent.Text = "总支出：" + recorder.TotalExpenditure;
            ProfitContent.Text = "净收入：" + recorder.Profit;

            this.DefaultViewModel["Item"] = recorder;
            this.PurchaseList.ItemsSource = recorderItems.Where(s => s.Type == "purchase").ToList();
            this.IncomeList.ItemsSource = recorderItems.Where(s=>s.Type == "income").ToList();
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            //await StatusBar.GetForCurrentView().HideAsync();
            StatusBar.GetForCurrentView().BackgroundOpacity = 0;//.ShowAsync();

            ApplicationView.GetForCurrentView().SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
            
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected async override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StatusBar.GetForCurrentView().BackgroundOpacity = 1;//.ShowAsync();
            //await StatusBar.GetForCurrentView().ShowAsync();

            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void AddPurchase_Click(object sender, RoutedEventArgs e)
        {
            AddPurchaseContent dialog = new AddPurchaseContent();
            dialog.RecorderId = RecorderId;
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var recorderItems = await DbContext.Instance.Conn.QueryAsync<RecorderItem>("select * from RecorderItem where RecorderId = " + RecorderId);
                this.PurchaseList.ItemsSource = recorderItems.Where(s => s.Type == "purchase").ToList();
                this.IncomeList.ItemsSource = recorderItems.Where(s => s.Type == "income").ToList();
            }
            else if (result == ContentDialogResult.Secondary)
            {

            }

        }

        private async void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeContent dialog = new AddIncomeContent();
            dialog.RecorderId = RecorderId;
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var recorderItems = await DbContext.Instance.Conn.QueryAsync<RecorderItem>("select * from RecorderItem where RecorderId = " + RecorderId);
                this.PurchaseList.ItemsSource = recorderItems.Where(s => s.Type == "purchase").ToList();
                this.IncomeList.ItemsSource = recorderItems.Where(s => s.Type == "income").ToList();

            }
            else if (result == ContentDialogResult.Secondary)
            {

            }

        }
    }
}