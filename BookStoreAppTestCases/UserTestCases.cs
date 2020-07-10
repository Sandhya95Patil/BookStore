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
        public void User_Registration_ValidData_Return_Ok()
        {
            var data = new ShowModel()
            {
                FirstName = "abc",
                LastName = "xyz",
                Email = "abc" + DateTime.Now + "@gmail.com",
                Password = "abc12",
                IsActive = true
            };
            var response = userController.UserSignUp(data);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void User_Registration_Data_Null_Return_BadRequest()
        {
            ShowModel data = null;          
            var response = userController.UserSignUp(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void User_Login_ValidData_Return_Ok()
        {
            var data = new LoginShowModel()
            {
                Email = "yashmore@gmail.com",
                Password = "12345"
            };
            var response = userController.UserLogin(data);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void User_Login_EmptyFields_Return_Ok()
        {
            var data = new LoginShowModel()
            {
                Email = "",
                Password = ""
            };
            var response = userController.UserLogin(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
