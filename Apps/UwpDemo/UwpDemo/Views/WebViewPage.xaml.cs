using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UwpDemo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WebViewPage : Page
    {
        public WebViewPage()
        {
            this.InitializeComponent();
            wv.Source =new Uri(@"http://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id=ujsWSQtiAVY7uHGcmxQG9W9w&redirect_uri=oob&scope=netdisk");
        }

        private void wv_FrameNavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            //status.Text +="fns:"+ args.Uri.AbsoluteUri;
        }

        private void wv_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            //MessageDialog dialog = new MessageDialog(args.Uri.AbsoluteUri);
            //await dialog.ShowAsync();
            //status.Text += "ns"+args.Uri.AbsoluteUri;
            var url = args.Uri.AbsoluteUri;
            if (!string.IsNullOrEmpty(url))
            {
                if (url.Contains("http://openapi.baidu.com/oauth/2.0/login_success"))
                {
                    var paramStartPosition = url.IndexOf('#');
                    var paramString = url.Substring(paramStartPosition+1);
                   var paramArray = paramString.Split('&');
                   var accessTokenString = paramArray.SingleOrDefault(s => s.StartsWith("access_token"));
                    if (!string.IsNullOrEmpty(accessTokenString))
                    {
                        var accessToken = accessTokenString.Substring(accessTokenString.IndexOf('=')+1);
                        var localSettings = ApplicationData.Current.LocalSettings;
                        localSettings.Values["AccessToken"] = accessToken;

                        //this.Frame.Navigate(typeof(Page1),"",new Windows.UI.Xaml.Media.Animation.DrillInNavigationTransitionInfo());
                        SetFrame();

                    }
                }
            }
        }

        private void SetFrame()
        {
            AppShell appShell = Window.Current.Content as AppShell;
            if (appShell == null)
            {

                appShell = new AppShell();


                appShell.Language = Windows.Globalization.ApplicationLanguages.Languages[0];

                //appShell.AppFrame.NavigationFailed += OnNavigationFailed;


                //if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                //{
                //    //TODO: Load state from previously suspended application
                //}


                Window.Current.Content = appShell;
            }



            if (appShell.AppFrame.Content == null)
            {
                appShell.AppFrame.Navigate(typeof(LandingPage), null, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
            }



            // Ensure the current window is active
            Window.Current.Activate();
        }


    }
}
