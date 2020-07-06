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
    public class WishListController : ControllerBase
    {
        IWishListBL wishListBL;
        public WishListController(IWishListBL wishListBL)
        {
            this.wishListBL = wishListBL;
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddWishList(ShowWishListModel showWishListModel)
        {
            try
            {
                var data = await this.wishListBL.AddBookToWishList(showWishListModel);
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
        public async Task<IActionResult> GetWishList()
        {
            try
            {
                var data = await this.wishListBL.GetAllWishList();
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
    }
}
