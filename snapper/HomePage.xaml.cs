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

    }
}