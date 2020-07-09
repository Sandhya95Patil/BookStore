using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.ShowModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        IAdminBL adminBL; 
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
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
                    return this.BadRequest(new { status = "False", message = "Failed To Register" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult AdminLogin(LoginShowModel adminLoginShowModel)
        {
            try
            {
                var data =  this.adminBL.AdminLogin(adminLoginShowModel);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Login Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Login" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
