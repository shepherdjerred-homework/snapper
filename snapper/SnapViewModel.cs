using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using snapper.Annotations;

//
namespace snapper {
    class SnapViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private SnapView snap;

        public SnapViewModel(SnapView snap) {
            this.snap = snap;
        }

        public Int32 Id => snap.Id;

        public string Title {
            get => snap.Title;
            set {
                snap.Title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }

        public string Content {
            get => snap.Content;
            set {
                snap.Title = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Title"));
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e) {
            PropertyChanged?.Invoke(this, e);
        }

    }
}
