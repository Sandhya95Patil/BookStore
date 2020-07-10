using BookStoreApp.Controllers;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.ShowModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreAppTestCases
{
    public class BookTestCases
    {
        BookController bookController;
        IBookBL bookBL;
        IBookRL bookRL;
        public IConfiguration configuration;

        //private HttpResponseMessage response;

      //  private string token;

        public BookTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            this.bookRL = new BookRL(this.configuration);
            this.bookBL = new BookBL(this.bookRL);
            this.bookController = new BookController(this.bookBL);
        }

        [Fact]
        public void Given_AddBook_Request_Should_Return_Ok()
        {
            var model = new BookShowModel()
            {
                BooKTitle="Agnipankh",
                Author="Abdul Kalam",
                Language="Marathi",
                Category="Motivational",
                ISBN=6789,
                Price=234,
                Pages=250
            };
            var response = bookController.AddBook(model);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
