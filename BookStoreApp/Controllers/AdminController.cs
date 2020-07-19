//-----------------------------------------------------------------------
// <copyright file="AdminController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BookStoreApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using BusinessLayer.Interface;
    using CommonLayer.ResponseModel;
    using CommonLayer.ShowModel;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

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
        IConfiguration configuration;

        /// <summary>
        /// inject the dependancy
        /// </summary>
        /// <param name="adminBL"></param>
        public AdminController(IAdminBL adminBL, IConfiguration configuration)
        {
            this.adminBL = adminBL;
            this.configuration = configuration;
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
                    var token = this.CreateToken(data, "authenticate user role");
                        return this.Ok(new { status = "True", message = "Login Successfully", data, token });
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

        //Method to create JWT token
        private string CreateToken(LoginResponseModel responseModel, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:token"]));
                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, responseModel.UserRole));
                claims.Add(new Claim("Email", responseModel.Email.ToString()));
                claims.Add(new Claim("Id", responseModel.Id.ToString()));
                claims.Add(new Claim("TokenType", type));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
