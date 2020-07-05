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
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> UserSignUp(ShowModel showModel)
        {
            try
            {
                var data = await this.userBL.UserSignUp(showModel);
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

    }
}
