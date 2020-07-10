using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.ShowModel
{
    public class BookShowModel
    {
        [Required(ErrorMessage = "Title Required")]
        public string BooKTitle { get; set; }

        [Required(ErrorMessage = "Author Name Required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Book Language Required")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Book Category Required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "ISBN No Required")]
        public int ISBN { get; set; }

        [Required(ErrorMessage = "Price Of Book Required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Pages Required")]
        public int Pages { get; set; }
    }
}
