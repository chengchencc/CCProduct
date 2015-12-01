using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UwpDemo.Views.WayBook;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : BackButtonPage
    {
        ModelTest ViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new ModelTest();
            this.ViewModel.Name = "name1";
        }

        private void OpenDemoButton_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(AppShell),null,new Windows.UI.Xaml.Media.Animation.SlideNavigationTransitionInfo());
        }

        private void OpenWaybookButton_Click(object sender, RoutedEventArgs e)
        {
            base.Frame.Navigate(typeof(WayBookMainPage),null, new Windows.UI.Xaml.Media.Animation.SuppressNavigationTransitionInfo());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ModelTest model2 = new ModelTest();
            //model2.Name = "2222";
            this.ViewModel.Name = DateTime.Now.ToString();

            //var model = new ModelTest();
            //model.Name = DateTime.Now.ToString();
            //this.ViewModel = model;
        }
    }

    public class ModelTest :  INotifyPropertyChanged
    {

        private string _name;

        public event PropertyChangedEventHandler PropertyChanged;// = delegate { };

        public ModelTest()
        {
            this.Name = "Next";
        }

        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name!=value)
                {
                    this._name = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                // Raise the PropertyChanged event, passing the name of the property whose value has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
