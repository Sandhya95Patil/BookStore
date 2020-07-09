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
    public class PurchaseController : ControllerBase
    {
        IPurchaseBL purchaseBL;
        public PurchaseController(IPurchaseBL purchaseBL)
        {
            this.purchaseBL = purchaseBL;
        }

        [HttpPost]
        [Route("")]
        public IActionResult PurchaseBook(ShowPurchaseBookModel showPurchaseBookModel)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data = this.purchaseBL.BookPurchase(claim, showPurchaseBookModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Orderd Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Orderd Book" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

    }
}
