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
            var model = new ShowModel()
            {
                FirstName = "sandhya",
                LastName = "patil",
                Email = "sandhyapatil@gmail.com",
                Password = "sandhya",
                IsActive = true
            };
            Assert.NotNull(model);
        }

        [Fact]
        public void Given_Request_For_Register_Admin_Should_Return_Ok()
        {
            var model = new ShowModel()
            {
                FirstName = "sandhya",
                LastName = "patil",
                Email = "saurabhnavdkar@gmail.com", 
                Password = "sandhya",
                IsActive = true
            };
            var response = adminController.AdminSignUp(model);
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
