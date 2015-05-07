﻿using WayBook.Common;
using WayBook.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
using Windows.UI.ViewManagement;
using Windows.UI;
using Newtonsoft.Json;
using WayBook.DataModel;
using WayBook.Services;

// The Hub Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WayBook
{
    public sealed partial class BusPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

        public BusPage()
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
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data.
            //var group = await SampleDataSource.GetGroupAsync((string)e.NavigationParameter);
            //var group = await RecentlySearchedBusLinesSource.GetAllAsync();
            //this.DefaultViewModel["Group"] = group.RecentlyBusLines;
            //StatusBar.GetForCurrentView().BackgroundColor = Colors.CornflowerBlue;
            StatusBar.GetForCurrentView().BackgroundOpacity = 0;

        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
            //StatusBar.GetForCurrentView().BackgroundColor = Colors.Black;
            //StatusBar.GetForCurrentView().BackgroundOpacity = 0;
        }

        /// <summary>
        /// Shows the details of an item clicked on in the <see cref="ItemPage"/>
        /// </summary>
        /// <param name="sender">The GridView displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        private void BusLineListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = (StationInfo)e.ClickedItem;
            if (!Frame.Navigate(typeof(ItemPageNew), itemId))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
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
        /// <param name="e">Event data that describes how this page was reached.</param>
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
            if (!Frame.Navigate(typeof(SearchBusLinePage)))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
            //Utilities.ShowImageTextToast("","ttttt");
        }


        private async void autoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //List<string> autoSuggestBoxSource = new List<string>() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3", "D1", "D2", "D3" };
            //var text = sender.Text;
            //autoSuggestBox.ItemsSource = autoSuggestBoxSource.Where(s => s.StartsWith(text, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(sender.Text))
            {
                // var GetBuslineUrl = Resources.SingleOrDefault(s => s.Key == "GetBuslineUrl");
                //var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/" + sender.Text + "/0/20");
                var url = UrlServices.Instance.GetBusLineUrl(sender.Text);


                if (RestfulClient.LatestRequest !=null&& !RestfulClient.LatestRequest.IsCompleted)
                {
                    RestfulClient.LatestRequest.AsAsyncAction().Cancel();
                }
                var jsonResult = await RestfulClient.Get(url);

                if (!string.IsNullOrEmpty(jsonResult.Content))
                {
                    var busLines = JsonConvert.DeserializeObject<BusLine>(jsonResult.Content);
                    if (busLines.status.code != 0)
                    {
                        Utilities.ShowMessage(busLines.status.msg);
                        autoSuggestBox.ItemsSource = null;
                    }
                    else
                        autoSuggestBox.ItemsSource = busLines.result.result;
                }
                else
                {

                    //Utilities.ShowNotification(NotificationPanel);
                    Utilities.ShowMessage("网络连接失败，请检查网络连接！");
                    autoSuggestBox.ItemsSource = null;
                }

            }
        }

        private void autoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var selectedItem = (ResultItem)args.SelectedItem;
            if (!Frame.Navigate(typeof(ItemPageNew), selectedItem))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }

        }

        private void AnimationDemo_Click(object sender, RoutedEventArgs e)
        {

            if (!Frame.Navigate(typeof(AnimationDemoPage)))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }


        private async void busLinePivotItem_Loaded(object sender, RoutedEventArgs e)
        {
            var group = await RecentlySearchedBusLinesSource.GetAllAsync();
            BusLineListView.ItemsSource = group.RecentlyBusLines;
        }
        private void StationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


    }
}