using System;
using System.Collections.Generic;
using System.Linq;

namespace snapper {
    class InMemoryStore : Store {
        private Dictionary<Int32, Snap> Snaps;

        public InMemoryStore() {
            Snaps = new Dictionary<int, Snap>();
        }
        
        public override List<Snap> GetSnaps() {
            return Snaps.Values.ToList();
        }

        public override void SaveSnap(Snap snap) {
            Snaps[snap.Id] = snap;
        }

        public override void UpdateSnap(Snap snap) {
            
        }

        public override void DeleteSnap(Snap snap) {
            
        }

        public void AddTestData() {
            for (int i = 0; i < 100; i++) {
                Snap snap = new Snap(i, "Test " + i, "Content " + i);
                SaveSnap(snap);
            }
        }
    }
}
