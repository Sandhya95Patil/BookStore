//-----------------------------------------------------------------------
// <copyright file="WishListController.cs" company="BridgeLabz Solution">
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

    /// <summary>
    /// Wish list controller 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController : ControllerBase
    {
        IWishListBL wishListBL;
        public WishListController(IWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }
        [HttpPost]
        [Route("")]
        public IActionResult AddWishList(int userId, ShowWishListModel showWishListModel)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data = this.wishListBL.AddBookToWishList(claim, showWishListModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Added To WishList Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Add WishList" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetWishList()
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data =  this.wishListBL.GetAllWishList(claim);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "All Wish List", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "WishLists Not Available" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }


        [HttpDelete]
        [Route("{wishListId}")]
        public IActionResult DeleteWishList(int wishListId)
        {
            try
            {
                var claim = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
                    var data =  this.wishListBL.DeleteWishList(claim, wishListId);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Wish List Delete Successfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Delete Wish List" });
                    }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
