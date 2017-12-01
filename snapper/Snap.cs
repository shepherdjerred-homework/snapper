using System;
using System.Collections.Generic;

namespace snapper {
    class Snap {
        public Int32 Id { get; }
        public String Title { get; set; }
        public String Content { get; set; }

        public Snap(int id, string title, string content) {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}