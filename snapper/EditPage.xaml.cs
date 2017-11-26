

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

using Windows.UI.Xaml.Controls;

namespace snapper {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage {
        public EditPage() {
            InitializeComponent();

            ItemCollection items = snap_list.Items;
            items.Add("Snap 1");
            items.Add("Snap 2");
            items.Add("Snap 3");
            items.Add("Snap 4");
            items.Add("Snap 5");
        }
    }
}
