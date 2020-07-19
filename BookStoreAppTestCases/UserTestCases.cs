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
    using CommonLayer.ShowModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Service;
    using System;
    using Xunit;

    /// <summary>
    /// user test cases
    /// </summary>
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
            this.userController = new UserController(this.userBL, configuration);
        }

        /// <summary>
        /// given user registration valid data return ok
        /// </summary>
        [Fact]
        public void Given_User_Registration_ValidData_Return_Ok()
        {
            var data = new ShowModel()
            {
                FirstName = "abc",
                LastName = "xyz",
                Email = "abc" +DateTime.Now+ "@gmail.com",
                Password = "abc12",
                IsActive = true
            };
            var response = userController.UserSignUp(data);
            Assert.IsType<OkObjectResult>(response);
        }

        /// <summary>
        /// given user registration data null then return bad request
        /// </summary>
        [Fact]
        public void User_Registration_Data_Null_Return_BadRequest()
        {
            ShowModel data = null;          
            var response = userController.UserSignUp(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// given user login vali data return ok
        /// </summary>
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

        /// <summary>
        /// user login empty fields return bad request
        /// </summary>
        [Fact]
        public void User_Login_EmptyFields_Return_BadRequest()
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
