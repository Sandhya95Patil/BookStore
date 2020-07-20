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

        IList<BookAddModel> SearchBook(string searchWord);

        IList<BookAddModel> GetAllBooks();

        BookAddModel UpdateBookPrice(UpdateBookModel updateBookModel);

        bool DeleteBook(int bookId); 
    }
}
