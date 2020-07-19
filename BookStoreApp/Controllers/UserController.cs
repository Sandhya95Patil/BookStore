//-----------------------------------------------------------------------
// <copyright file="UserController.cs" company="BridgeLabz Solution">
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
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserBL userBL;

        IConfiguration configuration;
        public UserController(IUserBL userBL, IConfiguration configuration)
        {
            this.userBL = userBL;
            this.configuration = configuration;
        }

        /// <summary>
        /// User SignUp method
        /// </summary>
        /// <param name="showModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public IActionResult UserSignUp(ShowModel showModel)
        {
            try
            {
                var data = this.userBL.UserSignUp(showModel);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Register Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Register" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        /// <summary>
        /// user login method
        /// </summary>
        /// <param name="loginShowModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult UserLogin(LoginShowModel loginShowModel)
        {
            try
            {
                var data =  this.userBL.UserLogin(loginShowModel);
                if (data != null)
                {
                    var token = this.CreateToken(data, "authenticate user role");
                    return this.Ok(new { status = "True", message = "Login Successfully", data, token });
                }
                else
                {
                    return this.NotFound(new { status = "False", message = "Failed To Login" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
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
