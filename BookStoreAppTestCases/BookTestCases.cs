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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Service;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading;
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
            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(new ClaimsPrincipal());
            bookController.ControllerContext.HttpContext = contextMock.Object;
            Assert.NotNull(bookController.User);
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
        public void GetAllBooks()
        {
            var searchWord = "asp";
            var response = bookController.SearchBook(searchWord) as OkObjectResult;
            var items=Assert.IsType<List<BookAddModel>>(response.Value);
            Assert.Equal(3, items.Count);
        }
    }

/*    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
        {
        }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }*/
}
