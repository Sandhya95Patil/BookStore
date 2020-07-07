using BusinessLayer.Interface;
using CommonLayer.Model;
using CommonLayer.ShowModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public Task<BookAddModel> AddBook(BookShowModel bookShowModel)
        {
            try
            {
                var response = this.bookRL.AddBook(bookShowModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<List<BookAddModel>> SearchBook(string searchWord)
        {
            try
            {
               return  this.bookRL.SearchBook(searchWord);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public Task<List<BookAddModel>> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<BookAddModel> UpdateBookPrice(UpdateBookModel updateBookModel)
        {
            try
            {
                return this.bookRL.UpdateBookPrice(updateBookModel);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public Task<bool> DeleteBook(int bookId)
        {
            try
            {
                return this.bookRL.DeleteBook(bookId);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
