using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CommonLayer.Model
{
    public class BookAddModel
    {
        public string BooKTitle { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
