using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.ShowModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        ICartBL cartBL;
        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCart(ShowCartModel showCartModel)
        {
            try
            {
                var data = await this.cartBL.AddCart(showCartModel);
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
        public async Task<IActionResult> GetAllCart()
        {
            try
            {
                    var data = await this.cartBL.GetAllCart();
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
        public async Task<IActionResult> DeleteCart(int cartId)
        {
            try
            {
                var data = await this.cartBL.DeleteCart(cartId);
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
