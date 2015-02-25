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
    public sealed partial class AddPurchaseContent : ContentDialog
    {
        public int RecorderId { get; set; }
        public int Id { get; set; }
        public AddPurchaseContent()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Id == -1)
            {
                RecorderItem item = new RecorderItem();
                item.RecorderId = RecorderId;
                item.Title = ((ComboBoxItem)PurchaseTitle.SelectedValue).Content.ToString();
                item.PurchaseUnitPrice = Convert.ToDecimal(PurchaseUnitPrice.Text);
                item.PurchaseWeight = Convert.ToDecimal(PurchaseWeight.Text);
                item.PurchaseTotalPrice = Convert.ToDecimal(PurchaseTotalPrice.Text);
                item.Type = "purchase";
                item.CreatedDate = DateTime.Now;

                await DbContext.Instance.Conn.InsertAsync(item);
            }
            else
            {
                RecorderItem item = new RecorderItem();
                item.Id = Id;
                item.RecorderId = RecorderId;
                item.Title = ((ComboBoxItem)PurchaseTitle.SelectedValue).Content.ToString();
                item.PurchaseUnitPrice = Convert.ToDecimal(PurchaseUnitPrice.Text);
                item.PurchaseWeight = Convert.ToDecimal(PurchaseWeight.Text);
                item.PurchaseTotalPrice = Convert.ToDecimal(PurchaseTotalPrice.Text);
                item.Type = "purchase";
                //item.CreatedDate = DateTime.Now;

                await DbContext.Instance.Conn.UpdateAsync(item);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void PurchaseUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalTotalPrice();
        }

        private void PurchaseWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalTotalPrice();
        }

        private void CalTotalPrice()
        {
            var purchaseUnitPrice = string.IsNullOrEmpty(PurchaseUnitPrice.Text)?0: Convert.ToDecimal(PurchaseUnitPrice.Text);
            var purchaseWeight = string.IsNullOrEmpty(PurchaseWeight.Text)?0: Convert.ToDecimal(PurchaseWeight.Text);
            PurchaseTotalPrice.Text = (purchaseUnitPrice * purchaseWeight).ToString();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            if (Id!=-1)
            {
                var model =await DbContext.Instance.Conn.FindAsync<RecorderItem>(Id);
                var selectedIndex = (IncomeTitle)Enum.Parse(typeof(IncomeTitle), model.Title);
                PurchaseTitle.SelectedIndex = (int)selectedIndex;
                PurchaseTotalPrice.Text = model.PurchaseTotalPrice.ToString();
                PurchaseUnitPrice.Text = model.PurchaseUnitPrice.ToString();
                PurchaseWeight.Text = model.PurchaseWeight.ToString();
            }

        }

    }
}
