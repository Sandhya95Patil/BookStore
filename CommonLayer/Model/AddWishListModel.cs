using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AddWishListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
