using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationsExtensions.ToastContent;
using Windows.ApplicationModel.Resources;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace WayBook.Common
{
    public class Utilities
    {
        public static string GetStringFromResource(string key)
        {
            var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
            return resourceLoader.GetString(key);
        }

        #region Toast
        public static void ShowToast(string message)
        {
            ToastTemplateType toastTemplateXml = ToastTemplateType.ToastText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplateXml);
            //toastXml.
            var toastText = toastXml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = message;

            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

            //var customAlarmScheduledToast = new ScheduledToastNotification(toastXml, DateTime.Now.AddSeconds(10));
            //ToastNotificationManager.CreateToastNotifier().AddToSchedule(customAlarmScheduledToast);
        }
        public static void ShowTextToast(string message)
        {
            IToastNotificationContent toastContent = null;


            IToastText02 templateContent = ToastContentFactory.CreateToastText02();
            //templateContent.TextHeading.Text = "Heading text";
            templateContent.TextBodyWrap.Text = message;//"Body text that wraps over two lines";
            toastContent = templateContent;


            ToastNotification toast = toastContent.CreateNotification();

            // If you have other applications in your package, you can specify the AppId of
            // the app to create a ToastNotifier for that application
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        public static void ShowImageTextToast(string src, string message)
        {
            IToastNotificationContent toastContent = null;

            IToastImageAndText01 templateContent = ToastContentFactory.CreateToastImageAndText01();
            templateContent.Image.Src = "Assets/DarkGray.png";
            templateContent.TextBodyWrap.Text = message;
            toastContent = templateContent;

            // Create a toast from the Xml, then create a ToastNotifier object to show
            // the toast
            ToastNotification toast = toastContent.CreateNotification();

            // If you have other applications in your package, you can specify the AppId of
            // the app to create a ToastNotifier for that application
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
        #endregion

        #region message dialog

        public static async void ShowMessage(string message)
        {

            MessageDialog msgDialog = new MessageDialog(message);
            await msgDialog.ShowAsync();
        }
        public async void ShowMessageWithTryAgain(string message, UICommandInvokedHandler tryAgainCommand, UICommandInvokedHandler closeCommand)
        {

            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("No internet connection has been found.");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Try again",
                new UICommandInvokedHandler(tryAgainCommand)));
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(closeCommand)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }
        //private void CommandInvokedHandler(IUICommand command)
        //{
        //    // Display message showing the label of the command that was invoked
        //    //rootPage.NotifyUser("The '" + command.Label + "' command has been selected.",
        //    //    NotifyType.StatusMessage);
        //}
        #endregion

        #region Notification

        public static void ShowNotification(StackPanel notificationPanel)
        {

            Storyboard ShowNotification = new Storyboard();
            PopInThemeAnimation popInAnimation = new PopInThemeAnimation();
            //popInAnimation.TargetName = notificationPanel.Name;

            Storyboard HideNotification = new Storyboard();
            PopOutThemeAnimation popOutAnimation = new PopOutThemeAnimation();
            //popOutAnimation.TargetName = notificationPanel.Name;
            popOutAnimation.BeginTime = new TimeSpan(0, 0, 3);


            ShowNotification.Completed += (sender, e) =>
            {
                HideNotification.Begin();
            };


            Storyboard.SetTarget(popInAnimation, notificationPanel);
            Storyboard.SetTarget(popOutAnimation,notificationPanel);
            ShowNotification.Children.Add(popInAnimation);
            HideNotification.Children.Add(popOutAnimation);


            //if (!notificationPanel.Resources.ContainsKey("ShowNotification"))
            //{
            //    notificationPanel.Resources.Add("ShowNotification", ShowNotification);                
            //}
            //if (!notificationPanel.Resources.ContainsKey("HideNotification"))
            //{
            //    notificationPanel.Resources.Add("HideNotification", HideNotification);
            //}


            notificationPanel.Visibility = Windows.UI.Xaml.Visibility.Visible;
            ShowNotification.Begin();

        }


        #endregion


    }
}
