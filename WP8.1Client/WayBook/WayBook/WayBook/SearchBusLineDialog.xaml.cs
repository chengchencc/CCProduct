using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Newtonsoft.Json;
using WayBook.Common;
using WayBook.DataModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace WayBook
{
    public sealed partial class SearchBusLineDialog : ContentDialog
    {
        public SearchBusLineDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void autoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //List<string> autoSuggestBoxSource = new List<string>() { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3", "D1", "D2", "D3" };
            //var text = sender.Text;
            //autoSuggestBox.ItemsSource = autoSuggestBoxSource.Where(s => s.StartsWith(text, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(sender.Text))
            {
                //var jsonResult = await HttpClientWapper.Instance.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/" + sender.Text + "/0/20");
                var jsonResult = await RestfulClient.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/" + sender.Text + "/0/20");
                var busLines = JsonConvert.DeserializeObject<BusLine>(jsonResult.Content);
                autoSuggestBox.ItemsSource = busLines.result.result;
            }

        }

    }
}
