//-----------------------------------------------------------------------
// <copyright file="AdminController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BookStoreApp.Controllers
{
    using System;
    using BusinessLayer.Interface;
    using CommonLayer.ShowModel;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Admin controller class
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// create field of admin interface of businness layer
        /// </summary>
        IAdminBL adminBL; 

        /// <summary>
        /// inject the dependancy
        /// </summary>
        /// <param name="adminBL"></param>
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        /// <summary>
        /// admin signup method
        /// </summary>
        /// <param name="adminShowModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUp")]
        public IActionResult AdminSignUp(ShowModel adminShowModel)
        {
            try
            {
                var data =  this.adminBL.AdminSignUp(adminShowModel);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Register Successfully", data });
                }
                else
                {
                    return this.Conflict(new { status = "False", message = "Email Already Present" });
                }
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { status = "False", message = "Given Data Null", exception.Message });
            }
        }

        /// <summary>
        /// admin login method
        /// </summary>
        /// <param name="adminLoginShowModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult AdminLogin(LoginShowModel adminLoginShowModel)
        {
            try
            {
                    var data = this.adminBL.AdminLogin(adminLoginShowModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Login Successfully", data });
                    }
                    else
                    {
                        return this.NotFound(new { status = "False", message = "Email Id Not Present In The System" });
                    }
            }
            catch (Exception)
            {
                return this.BadRequest(new { status = "False", message = "Email Id Not Present In The System" });
            }
        }
    }
}
