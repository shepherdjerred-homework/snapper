using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace snapper
{
    public sealed partial class HomePage
    {
        private StoreViewModel store;

        public HomePage()
        {
            InitializeComponent();
            LoadFromStore();
            SelectFirstSnap();
        }

        private void LoadFromStore()
        {
            store       = new StoreViewModel(new SqliteStore());
            SnapList.ItemsSource = store.Snaps;
            SnapText.Text = SnapList.Items.Count + " Snaps";
        }

        private void SelectFirstSnap()
        {
            if (SnapList.Items != null && SnapList.Items.Count > 0)
            {
                SnapList.SelectedIndex = 0;
            }
        }

        private void SnapListAddButton_OnClick(object sender, RoutedEventArgs e)
        {
            Snap newSnap = new Snap(store.Snaps.Count, "Title", "Content");
            store.AddSnap(newSnap);
            SnapList.SelectedIndex = SnapList.Items.Count - 1;
            SnapList.ScrollIntoView(SnapList.SelectedItem);
            SnapText.Text = SnapList.Items.Count + " Snaps";

            SnapContent.Focus(FocusState.Programmatic);
        }

        private void SnapListRemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            int tempIndex = SnapList.SelectedIndex;

            if (SnapList.Items != null && SnapList.Items.Count > 0)
            {
                

                if (AutoSuggestBox.Text != "")
                {
                    //get object being deleted and reference back to the original data source -- we're filtering data

                    var baseobj = SnapList.SelectedItem;
                    var myObject = baseobj as snapper.SnapViewModel;
                    var newIndex = store.Snaps.IndexOf(myObject);
                    store.DeleteSnap(store.Snaps[newIndex]);
                    store.Snaps.RemoveAt(newIndex);
                    updateList();
                }
                else
                {
                    store.DeleteSnap(store.Snaps[SnapList.SelectedIndex]);
                    store.Snaps.Remove(store.Snaps[SnapList.SelectedIndex]);
                }

                SnapText.Text = SnapList.Items.Count + " Snaps";

                if (tempIndex == SnapList.Items.Count)
                {
                    SnapList.SelectedIndex = tempIndex - 1;
                }
                else
                {
                    SnapList.SelectedIndex = tempIndex;
                }

                SnapList.ScrollIntoView(SnapList.SelectedItem);
            }
        }

        private void SnapList_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var baseobj = e.OriginalSource as FrameworkElement;
            var myObject = baseobj.DataContext as snapper.SnapViewModel;
            var newIndex = SnapList.Items.IndexOf(myObject);
            SnapList.SelectedIndex = newIndex;
            SnapList.ScrollIntoView(SnapList.SelectedItem);
        }

        private void updateList()
        {
            var boxContents = AutoSuggestBox.Text.ToLower();
            var linqResults = store.Snaps.Where(snap => snap.Content.ToLower().Contains(boxContents) ||
                                                        snap.Title.ToLower().Contains(boxContents));
            if (boxContents == "")
            {
                SnapList.ItemsSource = store.Snaps;
                SnapText.Text = SnapList.Items.Count + " Snaps";
            }
            else
            {
                SnapList.ItemsSource = linqResults;
                SnapText.Text = linqResults.Count() + " Snaps";
            }
        }

        private void AutoSuggestBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var boxContents = AutoSuggestBox.Text.ToLower();
            var linqResults = store.Snaps.Where(snap => snap.Content.ToLower().Contains(boxContents) ||
                                                        snap.Title.ToLower().Contains(boxContents));
            if (boxContents == "")
            {
                SnapList.ItemsSource = store.Snaps;
                SnapText.Text = SnapList.Items.Count + " Snaps";
            }
            else
            {
                SnapList.ItemsSource = linqResults;
                SnapText.Text = linqResults.Count() + " Snaps";
            }
        }
    }
}