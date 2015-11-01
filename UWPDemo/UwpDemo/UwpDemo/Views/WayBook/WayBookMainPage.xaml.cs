using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Newtonsoft.Json;
using UwpDemo.Models;
using UwpDemo.Models.WayBook;
using UwpDemo.Utilities;
using WayBook.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpDemo.Views.WayBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WayBookMainPage : Page
    {
        public ObservableCollection<Contact> ViewModel;
        private ResultItem _lastSelectedItem;
        CCHttpClient httpClient;
        RegionServices RegionService;
        public WayBookMainPage()
        {
            this.InitializeComponent();

            httpClient = new CCHttpClient();
            RegionService = new RegionServices();

            ContactRepositories contactRep = new ContactRepositories();
            ViewModel = contactRep.All();
            if (ViewModel.Count > 0)
            {
                MasterListView.ItemsSource = ViewModel;
            }
            //List<ResultItem> searchLineBoxData = new List<ResultItem>();
            //searchLineBoxData.Add(new ResultItem() { endStationName="endStation", id="1", lineName="lineName", startStationName="startStation", localLineId="aaa" });
            //searchLineBoxData.Add(new ResultItem() { endStationName="endStation", id="1", lineName="lineName", startStationName="startStation", localLineId="aaa" });
            //searchLineBoxData.Add(new ResultItem() { endStationName="endStation", id="1", lineName="lineName", startStationName="startStation", localLineId= "aaa" });

            //SearchLineBox.ItemsSource = searchLineBoxData;

            var regionCode = "370100";
            DataServices.Instance.AddOrUpdate("Host", "60.216.101.229");
            RegionService.AddOrUpdate(regionCode);

        }

        #region Old pivot
        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null, new Windows.UI.Xaml.Media.Animation.CommonNavigationTransitionInfo());

        }
        #endregion

        #region domain Events
        private void BusLineListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var itemId = (StationInfo)e.ClickedItem;
            //if (!Frame.Navigate(typeof(ItemPageNew), itemId))
            //{
            //    var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
            //    throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            //}
        }

        private async void SearchBusLineBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (!Frame.Navigate(typeof(SearchBusLinePage)))
            //{
            //    var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
            //    throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            //}
            ////Utilities.ShowImageTextToast("","ttttt");
        }
        private async void SearchLineBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            httpClient.CancleAllRequest();
            
            var inputBusNo = sender.Text;
            if (string.IsNullOrEmpty(inputBusNo))
            {
                return;
            }
            var url = UrlServices.Instance.GetBusLineUrl(inputBusNo);
            
           var requestJsonString = await httpClient.GetString(url);

            if (string.IsNullOrEmpty(requestJsonString))
            {
                SearchLineBox.ItemsSource = null;
                return;
            }

           var busLines =  JsonConvert.DeserializeObject<BusLine>(requestJsonString);

            if (busLines.status.code!=0)
            {
                SearchLineBox.ItemsSource = null;
                return;
            }
           SearchLineBox.ItemsSource = busLines.result.result;

            ////List<string> autoSuggestBoxSource = new List<string>() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3", "D1", "D2", "D3" };
            ////var text = sender.Text;
            ////autoSuggestBox.ItemsSource = autoSuggestBoxSource.Where(s => s.StartsWith(text, StringComparison.OrdinalIgnoreCase));
            //if (!string.IsNullOrEmpty(sender.Text))
            //{
            //    // var GetBuslineUrl = Resources.SingleOrDefault(s => s.Key == "GetBuslineUrl");
            //    //var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/" + sender.Text + "/0/20");
            //    var url = UrlServices.Instance.GetBusLineUrl(sender.Text);


            //    if (RestfulClient.LatestRequest != null && !RestfulClient.LatestRequest.IsCompleted)
            //    {
            //        RestfulClient.LatestRequest.AsAsyncAction().Cancel();
            //    }
            //    var jsonResult = await RestfulClient.Get(url);

            //    if (!string.IsNullOrEmpty(jsonResult.Content))
            //    {
            //        var busLines = JsonConvert.DeserializeObject<BusLine>(jsonResult.Content);
            //        if (busLines.status.code != 0)
            //        {
            //            Utilities.ShowMessage(busLines.status.msg);
            //            autoSuggestBox.ItemsSource = null;
            //        }
            //        else
            //            autoSuggestBox.ItemsSource = busLines.result.result;
            //    }
            //    else
            //    {

            //        //Utilities.ShowNotification(NotificationPanel);
            //        Utilities.ShowMessage("网络连接失败，请检查网络连接！");
            //        autoSuggestBox.ItemsSource = null;
            //    }

            //}
        }

        private void SearchLineBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

            var clickedItem = (ResultItem)args.SelectedItem;
            _lastSelectedItem = clickedItem;

            if (AdaptiveStates.CurrentState == NarrowState)
            {
                // Use "drill in" transition for navigating from master list to detail view
                Frame.Navigate(typeof(BasicPage), clickedItem, new DrillInNavigationTransitionInfo());
            }
            else
            {
                // Play a refresh animation when the user switches detail items.
                EnableContentTransitions();
            }

            //var selectedItem = (ResultItem)args.SelectedItem;
            //if (!Frame.Navigate(typeof(ItemPageNew), selectedItem))
            //{
            //    var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
            //    throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            //}

        }

        private void SearchLineBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private async void busLinePivotItem_Loaded(object sender, RoutedEventArgs e)
        {
            //var group = await RecentlySearchedBusLinesSource.GetAllAsync();
            //BusLineListView.ItemsSource = group.RecentlyBusLines;
        }

        private void StationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        #endregion

        #region Layout change events
        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (ResultItem)e.ClickedItem;
            _lastSelectedItem = clickedItem;

            if (AdaptiveStates.CurrentState == NarrowState)
            {
                // Use "drill in" transition for navigating from master list to detail view
                Frame.Navigate(typeof(BasicPage), e.ClickedItem, new DrillInNavigationTransitionInfo());
            }
            else
            {
                // Play a refresh animation when the user switches detail items.
                EnableContentTransitions();
            }
        }

        private void EnableContentTransitions()
        {
            DetailContentPresenter.ContentTransitions.Clear();
            DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }
        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && _lastSelectedItem != null)
            {
                // Resize down to the detail item. Don't play a transition.
                Frame.Navigate(typeof(BasicPage), _lastSelectedItem, new SuppressNavigationTransitionInfo());
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }
        #endregion

    }
}
