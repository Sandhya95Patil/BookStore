//-----------------------------------------------------------------------
// <copyright file="AdminTestCases.cs" company="BridgeLabz Solution">
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
    /// Admin tests class
    /// </summary>
    public class AdminTestCases
    {
        AdminController adminController;
        IAdminBL adminBL;
        IAdminRL adminRL;
        public IConfiguration configuration;

        /// <summary>
        /// initializes the fields
        /// </summary>
        public AdminTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            this.adminRL = new AdminRL(this.configuration);
            this.adminBL = new AdminBL(this.adminRL);
            this.adminController = new AdminController(this.adminBL, configuration);
        }

        /// <summary>
        /// Given admin registration request null should return bad request
        /// </summary>
        [Fact]
        public void Given_Admin_Registration_Request_Null_Should_Return_BadRequest()
        {
            ShowModel data = null;
            var response = adminController.AdminSignUp(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// given request for register admin should return ok
        /// </summary>
        [Fact]
        public void Given_Request_For_Register_Admin_Should_Return_Ok()
        {
            var data = new ShowModel()
            {
                FirstName = "sonu",
                LastName = "patil",
                Email = "sonupatil@gmail.com", 
                Password = "sonu",
                IsActive = true
            };
            var response = adminController.AdminSignUp(data);
            Assert.IsType<OkObjectResult>(response);
        }

        /// <summary>
        /// given request for register admin 
        /// </summary>
        [Fact]
        public void Given_Request_For_Register_Admin_AlreadyPresent_Email_Should_Return_BadRequest()
        {
            var data = new ShowModel()
            {
                FirstName = "sonu",
                LastName = "patil",
                Email = "swamimore@gmail.com",
                Password = "sonu",
                IsActive = true
            };
            var response = adminController.AdminSignUp(data);
            Assert.IsType<ConflictObjectResult>(response);
        }

        /// <summary>
        /// given request for admin login should return ok 
        /// </summary>
        [Fact]
        public void Given_Request_For_Admin_Login_Should_Return_Ok()
        {
            var data = new LoginShowModel()
            {
                Email = "swamimore@gmail.com",
                Password = "12345",
            };
            var response = adminController.AdminLogin(data);
            Assert.IsType<OkObjectResult>(response);
        }

        /// <summary>
        /// given request for admin login not provide email then return not ok
        /// </summary>
        [Fact]
        public void Given_Request_For_Admin_Login_Not_Provide_Email_Then_Return_NotOK()
        {
            var data = new LoginShowModel()
            {
                Email = "",
                Password = "12345",
            };
            var response = adminController.AdminLogin(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// given request for admin login not provide password then return not ok
        /// </summary>
        [Fact]
        public void Given_Request_For_Admin_Login_Not_Provide_Password_Then_Return_NotOK()
        {
            var data = new LoginShowModel()
            {
                Email = "swamimore@gmail.com",
                Password = "",
            };
            var response = adminController.AdminLogin(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// admin login invalid data return not found
        /// </summary>
        [Fact]
        public void AdminLogin_InValidLoginData_Return_NotFoundResult()
        {
            var data = new LoginShowModel()
            {
                Email = "abc@gmail.com",
                Password = "abc"
            };
            var response = adminController.AdminLogin(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// admin login email no dot in between gmail then return bad request
        /// </summary>
        [Fact]
        public void AdminLogin_Email_NoDot_Return_BadRequest()
        {
            var data = new LoginShowModel
            {
                Email = "swamimore@gmailcom",
                Password = "12345"
            };
            var response = adminController.AdminLogin(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        /// <summary>
        /// admin login data null return bad request
        /// </summary>
        [Fact]
        public void AdminLogin_Data_Null_Return_BadRequest()
        {
            LoginShowModel loginShowModel = null;
            var response = adminController.AdminLogin(loginShowModel);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
