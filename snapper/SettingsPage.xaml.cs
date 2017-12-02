using System;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace snapper
{
    public sealed partial class SettingsPage : Page
    {

        public SettingsPage()
        {
            this.InitializeComponent();

            if ((ElementTheme)ApplicationData.Current.LocalSettings.Values["AppTheme"] == ElementTheme.Dark)
            {
                DarkButton.IsChecked = true;
            }
            else
            {
                LightButton.IsChecked = true;
            }
        }

        private async void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (LightButton.IsChecked == true)
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)ElementTheme.Light;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)ElementTheme.Dark;
            }

            MessageDialog msgDialog = new MessageDialog("Changing the theme requires restarting the application, would you like to restart now?");
            UICommand cancelCommand = new UICommand("Cancel");
            UICommand restartCommand = new UICommand("Restart");
            msgDialog.Commands.Add(restartCommand);

            msgDialog.Commands.Add(cancelCommand);

            IUICommand command = await msgDialog.ShowAsync();

            if (command.Equals(restartCommand))
            {
                AppRestartFailureReason result = await CoreApplication.RequestRestartAsync("");
            }
        }

    }
}
