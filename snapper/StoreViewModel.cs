using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace snapper {
    class StoreViewModel : INotifyPropertyChanged {
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

        public void AddSnap(Snap newSnap) {
            SnapViewModel snapViewModel = new SnapViewModel(newSnap);
            snapViewModel.PropertyChanged += Snap_OnNotifyPropertyChanged;
            store.SaveSnap(newSnap);
            snaps.Add(snapViewModel);
        }

        public void DeleteSnap(SnapViewModel snap) {
            store.DeleteSnap(new Snap(snap.Id, snap.Title, snap.Content));
        }

        public void Update(Snap snap) {
        }

        public StoreViewModel(Store store) {
            this.store = store;
            snaps = new ObservableCollection<SnapViewModel>();

            foreach (Snap snap in store.GetSnaps()) {
                SnapViewModel snapViewModel = new SnapViewModel(snap);
                snapViewModel.PropertyChanged += Snap_OnNotifyPropertyChanged;
                snaps.Add(snapViewModel);
            }
        }

        private void OnPropertyChanged(Object sender, PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }

        void Snap_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e) {
            SnapViewModel snap = (SnapViewModel) sender;
            store.UpdateSnap(new Snap(snap.Id, snap.Title, snap.Content));
        }
    }
}