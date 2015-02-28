
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.UI.Popups;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace AppStudio.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class UploadStreamPage : Page
    {

        private NavigationHelper navigationHelper;
        
        private HttpClient httpClient;

        // A pointer back to the main page.  This is needed if you want to call methods in MainPage such
        // as NotifyUser()
        MainPage rootPage;



        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public UploadStreamPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
            httpClient = new HttpClient();
            rootPage = e.Content as MainPage;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void Upload_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string url = "http://localhost:2016/upload/index";
            Uri resourceAddress;

            string filePath = "/Assets/Data/RSSDataSource1.json";
            
            // The value of 'AddressField' is set by the user and is therefore untrusted input. If we can't create a
            // valid, absolute URI, we'll notify the user about the incorrect input.
            if (!Helpers.TryGetUri(url, out resourceAddress))
            {
                await ShowNotifyBox("Invalid URI.");
                return;
            }

            //await ShowNotifyBox("In progress");
            RequestProgressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
            RequestProgressBar.Value = 0;
           // rootPage.NotifyUser("In progress", NotifyType.StatusMessage);
            
            try
            {
                //Stream stream = await UploadStorage.ConvertTempFileToStream("RSSDataSource");
                Stream stream = await UploadStorage.ConvertStaticFileToStream(filePath);
                if (stream == null)
                {
                    await ShowNotifyBox("此文件为空，或者无此文件！");
                }
                HttpStreamContent streamContent = new HttpStreamContent(stream.AsInputStream());
                
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, resourceAddress);
                request.Content = streamContent;
                
                // Do an asynchronous POST.
                CancellationTokenSource cts = new CancellationTokenSource();
                IProgress<HttpProgress> progress = new Progress<HttpProgress>(ProgressHandler);
                HttpResponseMessage response = await httpClient.SendRequestAsync(request).AsTask(cts.Token,progress);
                //HttpResponseMessage response = await httpClient.PostAsync(resourceAddress, streamContent).AsTask(cts.Token,progress);//.SendRequestAsync(request).AsTask(cts.Token);

                
                //await ShowNotifyBox("Completed");

                //rootPage.NotifyUser("Completed", NotifyType.StatusMessage);
            }
            catch (TaskCanceledException)
            {
                //rootPage.NotifyUser("Request canceled.", NotifyType.ErrorMessage);
                //ShowNotifyBox("Request canceled.").Wait();
            }
            catch (Exception ex)
            {
                //rootPage.NotifyUser("Error: " + ex.Message, NotifyType.ErrorMessage);
               // ShowNotifyBox("Error:"+ex.Message).Wait();
            }
            finally
            {
                RequestProgressBar.Value = 100;
            }
        }

        private static async System.Threading.Tasks.Task ShowNotifyBox( string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        public void ProgressHandler(HttpProgress progress)
        {
            //StageField.Text = progress.Stage.ToString();
            //RetriesField.Text = progress.Retries.ToString(CultureInfo.InvariantCulture);
            //BytesSentField.Text = progress.BytesSent.ToString(CultureInfo.InvariantCulture);
            //BytesReceivedField.Text = progress.BytesReceived.ToString(CultureInfo.InvariantCulture);

            ulong totalBytesToSend = 0;
            if (progress.TotalBytesToSend.HasValue)
            {
                totalBytesToSend = progress.TotalBytesToSend.Value;
                //TotalBytesToSendField.Text = totalBytesToSend.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                //TotalBytesToSendField.Text = "unknown";
            }

            ulong totalBytesToReceive = 0;
            if (progress.TotalBytesToReceive.HasValue)
            {
                totalBytesToReceive = progress.TotalBytesToReceive.Value;
                //TotalBytesToReceiveField.Text = totalBytesToReceive.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                //TotalBytesToReceiveField.Text = "unknown";
            }

            double requestProgress = 0;
            if (progress.Stage == HttpProgressStage.SendingContent && totalBytesToSend > 0)
            {
                    requestProgress = progress.BytesSent * 50 / totalBytesToSend;
            }
            else if (progress.Stage == HttpProgressStage.ReceivingContent)
            {
                // Start with 50 percent, request content was already sent.
                requestProgress += 50;

                if (totalBytesToReceive > 0)
                {
                    requestProgress += progress.BytesReceived * 50 / totalBytesToReceive;
                }
            }
            else
            {
                return;
            }

            RequestProgressBar.Value = requestProgress;
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
