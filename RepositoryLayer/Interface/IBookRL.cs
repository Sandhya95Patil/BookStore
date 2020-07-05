using CommonLayer.Model;
using CommonLayer.ShowModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        Task<BookAddModel> AddBook(BookShowModel bookShowModel);
    }
}
