using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Popups;
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
    public sealed partial class AddItem : ContentDialog
    {
        public int RecorderId { get; set; }
        public AddItem()
        {
            this.InitializeComponent();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var nearbyList =await DbContext.Instance.Conn.QueryAsync<Recorder>("select * from Recorder where HappenDate BETWEEN ? AND ?", HappenDate.Date.DateTime.AddDays(-1),HappenDate.Date.DateTime.AddDays(1));
            var existed = nearbyList.Where(s => s.HappenDate.Date == HappenDate.Date.DateTime.Date).ToList();
            if (existed.Count==0)
            {
                var recorder = new Recorder();
                recorder.HappenDate = HappenDate.Date.DateTime;
                recorder.CreatedDate = DateTime.Now;

                //var createTableResult = await DbContext.GetInstance().Conn.CreateTableAsync<RecorderItem>();

                var id = await DbContext.GetInstance().Conn.InsertAsync(recorder);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("已经有这一天的记录了，无法重复添加！");
                await dialog.ShowAsync();
            }

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
