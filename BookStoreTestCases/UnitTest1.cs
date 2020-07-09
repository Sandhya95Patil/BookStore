using BookStoreApp.Controllers;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.ShowModel;
using Moq;
using RepositoryLayer.Interface;
using System;
using Xunit;

namespace BookStoreTestCases
{
    public class UnitTest1
    {
        AdminController adminController;
        IAdminBL adminBL;

        public UnitTest1()
        {
            var repository = new Mock<IAdminRL>();
            this.adminBL = new AdminBL(repository.Object);
            adminController = new AdminController(this.adminBL);
        }
            [Fact]
            public void Request_Of_Register_Account_Check_Not_Null()
            {
                var model = new ShowModel()
                {
                    FirstName = "sandhya",
                    LastName = "patil",
                    Email = "sandhya@gmail.com",
                    Password = "sandhya",
                    IsActive = true
                };
                Assert.NotNull(model);
            }
    }
}
