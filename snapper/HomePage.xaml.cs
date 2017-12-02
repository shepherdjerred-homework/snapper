using System.Collections.Specialized;
using Windows.UI.Xaml;

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
            InMemoryStore inMemoryStore = new InMemoryStore();
            inMemoryStore.AddTestData();
            store = new StoreViewModel(inMemoryStore);
            
            SnapList.ItemsSource = store.Snaps;
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
        }

        private void SnapListRemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            int tempIndex = SnapList.SelectedIndex;
            store.Snaps.RemoveAt(SnapList.SelectedIndex);

            if (SnapList.Items != null && SnapList.Items.Count > 0)
            {
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
    }
}