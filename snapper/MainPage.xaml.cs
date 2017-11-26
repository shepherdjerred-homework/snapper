﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace snapper {
    public sealed partial class MainPage {
        public MainPage() {
            InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e) {
            foreach (NavigationViewItemBase item in NavView.MenuItems) {
                if (item is NavigationViewItem && item.Tag.ToString() == "edit") {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args) {
            if (args.IsSettingsInvoked) {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else {
                switch (args.InvokedItem) {
                    case "Home":
                        ContentFrame.Navigate(typeof(HomePage));
                        break;
                    case "Edit":
                        ContentFrame.Navigate(typeof(EditPage));
                        break;
                    case "About":
                        ContentFrame.Navigate(typeof(AboutPage));
                        break;
                }
            }
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args) {
            if (args.IsSettingsSelected) {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch (item.Tag) {
                    case "home":
                        ContentFrame.Navigate(typeof(HomePage));
                        break;
                    case "edit":
                        ContentFrame.Navigate(typeof(EditPage));
                        break;
                    case "about":
                        ContentFrame.Navigate(typeof(AboutPage));
                        break;
                }
            }
        }
    }
}