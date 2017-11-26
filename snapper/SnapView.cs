using System;
using System.Collections.Generic;

namespace snapper {
    class SnapView {
        public Int32 Id { get; }
        public String Title { get; set; }
        public String Content { get; set; }

        public SnapView(int id, string title, string content) {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}