using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class TouchDevelopPlayer : Page
    {
        private string _id;
        private NavigationHelper _navigationHelper;

        public TouchDevelopPlayer()
        {
            InitializeComponent();

            _navigationHelper = new NavigationHelper(this);
            DataContext = this;

            this.Loaded += (sender, args2) =>
            {
                webView.ScriptNotify += (sender2, args) =>
                {
                    var v = args.Value;
                    if (v == "exit")
                    {
                        this._navigationHelper.GoBack();
                    }
                };
            };
        }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _id = e.Parameter as string;
            OpenScript(_id);

            _navigationHelper.OnNavigatedTo(e);
        }

        private void OpenScript(string id)
        {
            webView.Navigate(new Uri(string.Format("ms-appx-web:///Assets/TouchDevelop/{0}/index.html?ignoreAgent", id)));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            webView.Navigate(new Uri("about:blank"));
            _navigationHelper.OnNavigatedFrom(e);
        }
    }
}
