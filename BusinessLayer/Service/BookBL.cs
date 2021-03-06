﻿//-----------------------------------------------------------------------
// <copyright file="BookBL.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BusinessLayer.Service
{
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Book class
    /// </summary>
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public BookAddModel AddBook(BookShowModel bookShowModel)
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

        public IList<BookAddModel> SearchBook(string searchWord)
        {
            try
            {
               return this.bookRL.SearchBook(searchWord);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }


        public IList<BookAddModel> GetAllBooks()
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

        public BookAddModel UpdateBookPrice(UpdateBookModel updateBookModel)
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

        public bool DeleteBook(int bookId)
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
