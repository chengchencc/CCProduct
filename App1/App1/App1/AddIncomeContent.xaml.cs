using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using App1.Common.Model;
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
    public sealed partial class AddIncomeContent : ContentDialog
    {
        public int RecorderId { get; set; }
        public AddIncomeContent()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            RecorderItem item = new RecorderItem();
            item.RecorderId = RecorderId;
            item.SellUnitPrice = Convert.ToDecimal(SellUnitPrice.Text);
            item.SellWeight =Convert.ToDecimal(SellWeight.Text);
            item.SellTotalPrice = Convert.ToDecimal(SellTotalPrice.Text);
            item.Type = "income";
            item.CreatedDate = DateTime.Now;

            await DbContext.Instance.Conn.InsertAsync(item);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void SellUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalTotalPrice();
        }

        private void SellWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalTotalPrice();
        }

        private void CalTotalPrice()
        {
            var sellUnitPrice = string.IsNullOrEmpty(SellUnitPrice.Text)?0: Convert.ToDecimal(SellUnitPrice.Text);
            var sellWeight = string.IsNullOrEmpty(SellWeight.Text) ? 0 : Convert.ToDecimal(SellWeight.Text);
            SellTotalPrice.Text = (sellUnitPrice * sellWeight).ToString();
        }

    }
}
