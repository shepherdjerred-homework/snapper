using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snapper {
    abstract class Store {
        public abstract List<Snap> GetSnaps();
        public abstract void SaveSnap(Snap snap);
        public abstract void UpdateSnap(Snap snap);
        public abstract void DeleteSnap(Snap snap);
    }
}
