// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using System.Collections.Generic;
using System.Diagnostics;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace snapper {
    public sealed partial class HomePage {
        private StoreViewModel store;
        private SnapViewModel selectedSnap;

        public HomePage() {
            InitializeComponent();

            LoadFromStore();
            SelectFirstSnap();
        }

        private void LoadFromStore() {
            InMemoryStore inMemoryStore = new InMemoryStore();
            inMemoryStore.AddTestData();
            store = new StoreViewModel(inMemoryStore);

            SnapList.ItemsSource = store.Snaps;
        }

        private void SelectFirstSnap() {
            // TODO Show some kind of tutorial if there are no snaps
            if (SnapList.Items.Count > 0) {
                SnapList.SelectedIndex = 0;
            }
        }

        private void UpdateSelectedSnap() {
            SnapTitle.Text = selectedSnap.Title;
            SnapContent.Text = selectedSnap.Content;
        }

        private void SnapList_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            selectedSnap = SnapList.SelectedItem as SnapViewModel;
            UpdateSelectedSnap();
        }

        // TODO This method is called when changing Snap selection.. it shouldn't
        private void SnapTitle_OnTextChanged(object sender, TextChangedEventArgs e) {
            Trace.WriteLine("Saving title");
            selectedSnap.Title = SnapTitle.Text;
        }

        // TODO This method is called when changing Snap selection.. it shouldn't
        private void SnapContent_OnTextChanged(object sender, RoutedEventArgs e) {
            Trace.WriteLine("Saving content");
            selectedSnap.Content = SnapContent.Text;
        }

        private void UpdateListViewSelectedSnap() {
            SnapViewModel snap = SnapList.SelectedItem as SnapViewModel;
            selectedSnap = snap;
        }
    }
}