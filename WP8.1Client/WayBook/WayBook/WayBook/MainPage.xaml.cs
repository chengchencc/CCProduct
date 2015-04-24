using WayBook.Common;
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
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using WayBook.Services;

// The Hub Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WayBook
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        private readonly ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("Resources");

        public RegionServices RegionService { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();

            // Hub is only supported in Portrait orientation
            //DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            this.NavigationCacheMode = NavigationCacheMode.Disabled;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
            RegionService = new RegionServices();
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
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = await SampleDataSource.GetGroupsAsync();
            this.DefaultViewModel["Groups"] = sampleDataGroups;

            InitialRegion();
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
        }

        /// <summary>
        /// Shows the details of a clicked group in the <see cref="SectionPage"/>.
        /// </summary>
        private void GroupSection_ItemClick(object sender, ItemClickEventArgs e)
        {
            var groupId = ((SampleDataGroup)e.ClickedItem).UniqueId;
            if (!Frame.Navigate(typeof(SectionPage), groupId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        /// <summary>
        /// Shows the details of an item clicked on in the <see cref="ItemPage"/>
        /// </summary>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            if (!Frame.Navigate(typeof(ItemPage), itemId))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
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

        #region DrawerLayoutEvent
        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsLeftDrawerOpen)
                DrawerLayout.CloseLeftDrawer();
            else
                DrawerLayout.OpenLeftDrawer();
        }

        private async void Item1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                string menuItemName = grid.Name;
                MessageDialog dialog = null;

                switch (menuItemName)
                {
                    case "Item1":
                        dialog = new MessageDialog("Ay caramba!");
                        break;
                    case "Item2":
                        dialog = new MessageDialog("Don't have a cow, man!");
                        break;
                    case "Item3":
                        dialog = new MessageDialog("Hey, Ottoman!");
                        break;
                    case "Item4":
                        dialog = new MessageDialog("Eat my shorts!");
                        break;
                }

                if (dialog != null) await dialog.ShowAsync();
            }
        }
        #endregion

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsRightDrawerOpen)
                DrawerLayout.CloseRightDrawer();
            else
                DrawerLayout.OpenRightDrawer();
        }

        private void BusBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Frame.Navigate(typeof(BusPage), "1"))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }
        private void TrainBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Utilities.ShowMessage("未开通");
        }
        private void AirLineBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Utilities.ShowMessage("未开通");
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            if (!Frame.Navigate(typeof(SectionPage), "1"))
            {
                throw new Exception(this.resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }

        private void positionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (Position)e.ClickedItem;
            position.Content = item.Name;
            //TODO:将选择的城市保存起来
        }

        private void InitialRegion()
        {
            List<Position> p = GenPosition();

            positionList.ItemsSource = p;

            Region.ItemsSource = p;
            Region.DisplayMemberPath = "Name";
            Region.SelectedValuePath = "Id";
            var regionCode = RegionService.Get();
            if (string.IsNullOrEmpty(regionCode))
            {
                regionCode = "370100";
                DataServices.Instance.AddOrUpdate("Host", "http://60.216.101.229");
                RegionService.AddOrUpdate(regionCode);
            }
            Region.SelectedValue = regionCode;
        }

        private List<Position> GenPosition()
        {
            List<Position> p = new List<Position>();
            p.Add(new Position { Id = "460200", Name = "三亚" });
            p.Add(new Position { Id = "320281", Name = "江阴" });
            p.Add(new Position { Id = "321200", Name = "泰州" });
            p.Add(new Position { Id = "321000", Name = "扬州" });
            p.Add(new Position { Id = "321100", Name = "镇江" });
            p.Add(new Position { Id = "230900", Name = "七台河" });
            p.Add(new Position { Id = "130100", Name = "石家庄" });
            p.Add(new Position { Id = "131000", Name = "廊坊" });
            p.Add(new Position { Id = "510500", Name = "泸州" });
            p.Add(new Position { Id = "411000", Name = "许昌" });
            p.Add(new Position { Id = "410881", Name = "济源" });
            p.Add(new Position { Id = "370100", Name = "济南" });
            p.Add(new Position { Id = "370800", Name = "济宁" });
            p.Add(new Position { Id = "370900", Name = "泰安" });
            p.Add(new Position { Id = "370300", Name = "淄博" });
            p.Add(new Position { Id = "371000", Name = "威海" });
            p.Add(new Position { Id = "371500", Name = "聊城" });
            p.Add(new Position { Id = "330100", Name = "杭州" });
            p.Add(new Position { Id = "330600", Name = "绍兴" });
            p.Add(new Position { Id = "431121", Name = "祁阳" });
            p.Add(new Position { Id = "210700", Name = "锦州" });
            p.Add(new Position { Id = "211400", Name = "葫芦岛" });
            return p;
        }

        private async void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var regionSelected = (ComboBox)sender;
            if (regionSelected.SelectedValue != null && !string.IsNullOrEmpty(regionSelected.SelectedValue.ToString()))
            {
                RegionService.AddOrUpdate(regionSelected.SelectedValue.ToString());
                var host = await RegionService.GetRegionHost(regionSelected.SelectedValue.ToString());
                DataServices.Instance.AddOrUpdate("Host", host);
            }
            
        }

    }

    class Position
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}
