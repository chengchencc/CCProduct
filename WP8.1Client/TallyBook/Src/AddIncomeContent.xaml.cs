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
using CC.Product.TallyBook.Common;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace App1
{
    public sealed partial class AddIncomeContent : ContentDialog
    {
        public int RecorderId { get; set; }
        public int Id { get; set; }
        public AddIncomeContent()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (Id==-1)
            {
            RecorderItem item = new RecorderItem();
            item.RecorderId = RecorderId;
            item.Title =((ComboBoxItem) IncomeTitle.SelectedValue).Content.ToString();
            item.SellUnitPrice = Utilities.StringToDecimal(SellUnitPrice.Text);
            item.SellWeight = Utilities.StringToDecimal(SellWeight.Text);
            item.SellTotalPrice = Utilities.StringToDecimal(SellTotalPrice.Text);
            item.Type = "income";
            item.CreatedDate = DateTime.Now;

            await DbContext.Instance.Conn.InsertAsync(item);
            }
            else
            {

                RecorderItem item = new RecorderItem();
                item.Id = Id;
                item.RecorderId = RecorderId;
                item.Title = ((ComboBoxItem)IncomeTitle.SelectedValue).Content.ToString();
                item.SellUnitPrice = Utilities.StringToDecimal(SellUnitPrice.Text);
                item.SellWeight = Utilities.StringToDecimal(SellWeight.Text);
                item.SellTotalPrice = Utilities.StringToDecimal(SellTotalPrice.Text);
                item.Type = "income";
                //item.CreatedDate = DateTime.Now;
                await DbContext.Instance.Conn.UpdateAsync(item);
            }
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
            var sellUnitPrice = Utilities.StringToDecimal(SellUnitPrice.Text);
            var sellWeight = Utilities.StringToDecimal(SellWeight.Text);
            SellTotalPrice.Text = (sellUnitPrice * sellWeight).ToString();
        }

        private async void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            if (Id!=-1)
            {
                var model =await DbContext.Instance.Conn.FindAsync<RecorderItem>(Id);
                var selectedIndex = (IncomeTitle)Enum.Parse(typeof(IncomeTitle), model.Title);
                IncomeTitle.SelectedIndex = (int)selectedIndex;
                SellTotalPrice.Text = model.SellTotalPrice.ToString();
                SellUnitPrice.Text = model.SellUnitPrice.ToString();
                SellWeight.Text = model.SellWeight.ToString();
            }
        }

    }
    enum IncomeTitle
    {
        卖粮食=0,
        其他=1
    }
}
