//-----------------------------------------------------------------------
// <copyright file="PurchaseController.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//-----------------------------------------------------------------------
namespace BookStoreApp.Controllers
{
    using System;
    using System.Linq;
    using BusinessLayer.Interface;
    using CommonLayer.ShowModel;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RepositoryLayer.MSMQ;

    /// <summary>
    /// Purchase controller class
    /// </summary>
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

        /// <summary>
        /// purchase book 
        /// </summary>
        /// <param name="showPurchaseBookModel"></param>
        /// <returns></returns>
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
                        var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
                        MSMQSender mSMQSender = new MSMQSender();
                        mSMQSender.Message(email);
                        return this.Ok(new { status = "True", message = "Book Ordred Successfully", data });
                    }
                    else
                    {
                        return this.NotFound(new { status = "False", message = "Not Found Cart Id Or May Be Already In Use" });
                    }
            }
            catch (Exception exception)

            {
                return BadRequest(new { status = "False",  message = exception.Message });
            }
        }

    }
}
