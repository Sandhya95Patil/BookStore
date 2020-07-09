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
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddCart(ShowCartModel showCartModel)
        {
            try
            {
                    var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data = this.cartBL.AddCart(claim, showCartModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Added To Cart Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Add Cart" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllCart()
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data =  this.cartBL.GetAllCart(claim);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "All Carts", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Get Carts" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete]
        [Route("{cartId}")]
        public IActionResult DeleteCart(int cartId)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data =  this.cartBL.DeleteCart(claim, cartId);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Cart Deleted Successfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Delete Carts" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
