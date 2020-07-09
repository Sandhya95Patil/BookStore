using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        BookAddModel AddBook(BookShowModel bookShowModel);

        List<BookAddModel> SearchBook(string searchWord);
        List<BookAddModel> GetAllBooks();
        BookAddModel UpdateBookPrice(UpdateBookModel updateBookModel);
        bool DeleteBook(int bookId); 
    }
}
