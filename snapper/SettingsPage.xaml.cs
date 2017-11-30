using Windows.Storage;
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

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (LightButton.IsChecked == true)
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)ElementTheme.Light;
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["AppTheme"] = (int)ElementTheme.Dark;
            }
        }

    }
}
