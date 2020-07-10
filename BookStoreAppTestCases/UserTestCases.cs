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
using System.Text;
using Xunit;

namespace BookStoreAppTestCases
{
    public class UserTestCases
    {
        UserController userController;
        IUserBL userBL;
        IUserRL userRL;
        IConfiguration configuration;

        public UserTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            this.userRL = new UserRL(this.configuration);
            this.userBL = new UserBL(this.userRL);
            this.userController = new UserController(this.userBL);
        }

        [Fact]
        public void Given_Request_For_Register_Admin_Should_Return_Ok()
        {
            var model = new ShowModel()
            {
                FirstName = "sonu",
                LastName = "patil",
                Email = "sonupatil" + DateTime.Now + "@gmail.com",
                Password = "sandhya",
                IsActive = true
            };
            var response = userController.UserSignUp(model);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
