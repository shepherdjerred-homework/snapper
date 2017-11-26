using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snapper {
    abstract class Store {
        public abstract List<SnapView> GetSnaps();
        public abstract void SaveSnap(SnapView snap);
    }
}
