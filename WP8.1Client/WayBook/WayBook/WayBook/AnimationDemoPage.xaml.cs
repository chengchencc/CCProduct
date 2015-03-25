using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WayBook.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WayBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AnimationDemoPage : Page
    {

        private readonly NavigationHelper navigationHelper;

        public AnimationDemoPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            
        }

        void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            
        }

        #region NavigationHelper registration
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
        #endregion
        private async void animateButton_Click(object sender, RoutedEventArgs e)
        {
            //CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
            //await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { });
            //animateImage.
            //if (animateImage.Opacity==0)
            //{
            //    ShowStoryboard.Begin();
            //}
            //else
            //{
            //    HideStoryboard.Begin();
            //}
            NotificationPanel.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ShowNotification.Begin();
            ShowNotification.Completed += ShowNotification_Completed;
            //HideNotification.Begin();
            
        }

        void ShowNotification_Completed(object sender, object e)
        {
            HideNotification.Begin();
        }

    }
}
