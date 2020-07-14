using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace CommonLayer.ShowModel
{
    public class ShowPurchaseBookModel
    {
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage ="Cart Id must be Greater Than 0")]
        public int CartId { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Book Id must be Greater Than 0")]
        public int BookId { get; set; }

        [Required]
        public string Address { get; set; }

    }
}
