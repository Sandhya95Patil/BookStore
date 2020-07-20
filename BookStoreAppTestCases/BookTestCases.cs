//-----------------------------------------------------------------------
// <copyright file="BookTestCases.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BookStoreAppTestCases
{
    using BookStoreApp.Controllers;
    using BusinessLayer.Interface;
    using BusinessLayer.Service;
    using CommonLayer.Model;
    using CommonLayer.ShowModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Service;
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Book tests class
    /// </summary>
    public class BookTestCases
    {
        BookController bookController;
        IBookBL bookBL;
        IBookRL bookRL;
        public IConfiguration configuration;

        /// <summary>
        /// Initializes the instances for test cases
        /// </summary>
        public BookTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            this.bookRL = new BookRL(this.configuration);
            this.bookBL = new BookBL(this.bookRL);
            this.bookController = new BookController(this.bookBL);

       
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void Given_AddBook_Data_Valid()
        {
            var data = new BookShowModel()
            {
                BooKTitle = "mvc",
                Author = "microsoft",
                Language = "English",
                Category = "Tech",
                ISBN=1290,
                Price=123,
                Pages=123
            };
            var response = bookController.AddBook(data);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Given_AddBook_DataNull_Return_BadRequest()
        {
            BookShowModel data = null;
            var response = bookController.AddBook(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Get_All_Books()
        {
            string searchWord = null;
            var response = bookController.SearchBook(searchWord) as OkObjectResult;
            var items=Assert.IsType<List<BookAddModel>>(response.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Search_Books()
        {
            string searchWord = "asp";
            var response = bookController.SearchBook(searchWord) as OkObjectResult;
            var items = Assert.IsType<List<BookAddModel>>(response.Value);
            Assert.Equal(3, items.Count);
        } 

        [Fact]
        public void Update_Book_By_Price_Return_OkResult()
        {
            var data = new UpdateBookModel()
            {
                BookId = 9,
                Price = 240
            };
            var response = bookController.UpdateBookPrice(data);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Update_Book_By_Price_BookId_LessThan_Zero_Return_BadObjectResult()
        {
            var data = new UpdateBookModel()
            {
                BookId = -9,
                Price = 240
            };
            var response = bookController.UpdateBookPrice(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Update_Book_By_Price_Price_LessThan_Zero_Return_BadObjectResult()
        {
            var data = new UpdateBookModel()
            {
                BookId = 13,
                Price = 0
            };
            var response = bookController.UpdateBookPrice(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Book_Book_ById_Return_OkObjectResult()
        {
            int bookId = 25;
            var response = bookController.DeleteBook(bookId);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Book_Book_ById_LessThan_Zero_Return_BadObjectResult()
        {
            int bookId = -7;
            var response = bookController.DeleteBook(bookId);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
