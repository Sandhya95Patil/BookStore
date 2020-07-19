//-----------------------------------------------------------------------
// <copyright file="IBookRL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of book 
    /// </summary>
    public interface IBookRL
    {
        BookAddModel AddBook(BookShowModel bookShowModel);
        Task<IList<BookAddModel>> SearchBook(string searchWord);
        Task<IList<BookAddModel>> GetAllBooks();
        BookAddModel UpdateBookPrice(UpdateBookModel updateBookModel);
        bool DeleteBook(int bookId);

    }
}
