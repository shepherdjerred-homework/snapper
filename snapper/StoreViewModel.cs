using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace snapper {
    class StoreViewModel : INotifyPropertyChanged  {

        public event PropertyChangedEventHandler PropertyChanged;

        private Store store;

        private ObservableCollection<SnapViewModel> snaps;

        public ObservableCollection<SnapViewModel> Snaps {
            get => snaps;
            set {
                snaps = value;
                OnPropertyChanged(this, new PropertyChangedEventArgs("Snaps"));
            }

        }

        public StoreViewModel(Store store) {
            this.store = store;
            snaps = new ObservableCollection<SnapViewModel>();

            foreach (Snap snap in store.GetSnaps()) {
                SnapViewModel snapViewModel = new SnapViewModel(snap);
                snapViewModel.PropertyChanged += OnPropertyChanged;
                snaps.Add(snapViewModel);
            }
        }

        private void OnPropertyChanged(Object sender, PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
    }
}
