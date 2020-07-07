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
    public class PurchaseController : ControllerBase
    {
        IPurchaseBL purchaseBL;
        public PurchaseController(IPurchaseBL purchaseBL)
        {
            this.purchaseBL = purchaseBL;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBook(ShowPurchaseBookModel showPurchaseBookModel)
        {
            try
            {
                var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (claim == "user")
                {
                    var data = await this.purchaseBL.BookPurchase(showPurchaseBookModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Purchase Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Purchase Book" });
                    }
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Sorry, You Are Not Able To Buy Book" });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

    }
}
