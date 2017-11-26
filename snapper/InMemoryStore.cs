using System;
using System.Collections.Generic;
using System.Linq;

namespace snapper {
    class InMemoryStore : Store {
        private Dictionary<Int32, SnapView> Snaps;

        public InMemoryStore() {
            Snaps = new Dictionary<int, SnapView>();
        }
        
        public override List<SnapView> GetSnaps() {
            return Snaps.Values.ToList();
        }

        public override void SaveSnap(SnapView snap) {
            Snaps[snap.Id] = snap;
        }

        public void AddTestData() {
            for (int i = 0; i < 100; i++) {
                SnapView snap = new SnapView(i, "Test " + i, "Content " + i);
                SaveSnap(snap);
            }
        }
    }
}
