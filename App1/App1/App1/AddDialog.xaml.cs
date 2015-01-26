using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace App1
{
    public sealed partial class AddDialog : ContentDialog
    {
        public AddDialog()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var recorder = new RecorderItem();
            recorder.HappenDate = HappenDate.Date.DateTime;
            recorder.PurchaseUnitPrice = Convert.ToDecimal( PurchaseUnitPrice.Text);
            recorder.PurchaseWeight = Convert.ToDecimal(PurchaseUnitPrice.Text);
            recorder.SellUnitPrice = Convert.ToDecimal(SellUnitPrice.Text);
            recorder.SellWeight = Convert.ToDecimal(SellWeight.Text);
            recorder.CreatedDate = DateTime.Now;
            var localDBPath = "db.sdf";
            var conn = new SQLiteAsyncConnection(localDBPath);
            var createTableResult = await conn.CreateTableAsync<RecorderItem>();
            var id = await conn.InsertAsync(recorder);
            //var resutl = await conn.QueryAsync<RecorderItem>("");
            //var all = await conn.Table<RecorderItem>().ToListAsync();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
