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
        Task<BookAddModel> AddBook(BookShowModel bookShowModel);

        Task<List<BookAddModel>> SearchBook(SearchBookModel searchBookModel);

    }
}
