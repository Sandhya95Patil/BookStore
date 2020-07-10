using BookStoreApp.Controllers;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.ShowModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using RepositoryLayer;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Data.SqlClient;
using Xunit;

namespace BookStoreAppTestCases
{
    public class AdminTestCases
    {
        AdminController adminController;
        IAdminBL adminBL;
        IAdminRL adminRL;
        public IConfiguration configuration;
        //IConfigurationBuilder configurationBuilder;

        public AdminTestCases()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            this.configuration = configurationBuilder.Build();
            this.adminRL = new AdminRL(this.configuration);
            this.adminBL = new AdminBL(this.adminRL);
            this.adminController = new AdminController(this.adminBL);
        }

        [Fact]
        public void Given_Request_For_Register_Admin_Should_Not_Null()
        {
            var data = new ShowModel()
            {
                FirstName = "sandhya",
                LastName = "patil",
                Email = "sandhyapatil@gmail.com",
                Password = "sandhya",
                IsActive = true
            };
            Assert.NotNull(data);
        }

        [Fact]
        public void Given_Admin_Registration_Request_Null_Should_Return_BadRequest()
        {
            ShowModel data = null;
            var response = adminController.AdminSignUp(data);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void Given_Request_For_Register_Admin_Should_Return_Ok()
        {
            var data = new ShowModel()
            {
                FirstName = "sonu",
                LastName = "patil",
                Email = "sonupatil" +DateTime.Now+ "@gmail.com", 
                Password = "sandhya",
                IsActive = true
            };
            var response = adminController.AdminSignUp(data);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Given_Request_For_Register_Admin_AlreadyPresent_Email_Should_Return_BadRequest()
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
            Assert.IsType<BadRequestObjectResult>(response);
        }

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

        [Fact]
        public void AdminLogin_Data_Null_Return_BadRequest()
        {
            LoginShowModel loginShowModel = null;
            var response = adminController.AdminLogin(loginShowModel);
            Assert.IsType<BadRequestObjectResult>(response);
        }
    }
}
