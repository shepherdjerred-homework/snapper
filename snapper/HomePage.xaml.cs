// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace snapper {
    public sealed partial class HomePage {
        private Store store;
        private SnapView selectedSnap;

        public HomePage() {
            InitializeComponent();

            LoadFromStore();
            SelectFirstSnap();
        }

        private void LoadFromStore() {
            InMemoryStore inMemoryStore = new InMemoryStore();
            inMemoryStore.AddTestData();
            store = inMemoryStore;

            SnapList.ItemsSource = store;
        }

        private void SelectFirstSnap() {
            // TODO Show some kind of tutorial if there are no snaps
            if (SnapList.Items.Count > 0) {
                SnapList.SelectedIndex = 0;
            }
        }

        private void UpdateSelectedSnap() {
            // Set the isChangingSnap field to true so we don't save the change to the store
            SnapTitle.Text = selectedSnap.Title;
            SnapContent.Text = selectedSnap.Content;
        }

        private void SnapList_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedSnap = SnapList.SelectedItem as SnapView;
            UpdateSelectedSnap();
        }

        // TODO This method is called when changing Snap selection.. it shouldn't
        private void SnapTitle_OnTextChanged(object sender, TextChangedEventArgs e) {
            Trace.WriteLine("Saving title");
            selectedSnap.Title = SnapTitle.Text;
            store.SaveSnap(selectedSnap);
        }

        // TODO This method is called when changing Snap selection.. it shouldn't
        private void SnapContent_OnTextChanged(object sender, RoutedEventArgs e) {
            Trace.WriteLine("Saving content");
            selectedSnap.Content = SnapContent.Text;
            store.SaveSnap(selectedSnap);
        }

        private void UpdateListViewSelectedSnap() {
            SnapView snap = SnapList.SelectedItem as SnapView;
            snap = selectedSnap;
        }

    }
}