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
    public class BookController : ControllerBase
    {
        IBookBL bookBL;
        public  BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBook(BookShowModel bookShowModel)
        {
            try
            {
                var data = await this.bookBL.AddBook(bookShowModel);
                if (data != null)
                {
                    return this.Ok(new { status = "True", message = "Book Added Successfully", data });
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Failed To Add Book" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
