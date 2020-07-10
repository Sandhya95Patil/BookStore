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
        public IActionResult AddBook(BookShowModel bookShowModel)
        {
            try
            {
                var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (claim == "admin")
                {
                    var data =  this.bookBL.AddBook(bookShowModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Added Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Add Book" });
                    }
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Sorry, You Are Not Able To Add Book" });
                }

            }
            
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult SearchBook([FromQuery]string searchWord)
        {
            try
            {
                if (searchWord != null)
                {
                    var data =  this.bookBL.SearchBook(searchWord);
                    if (data.Count != 0)
                    {
                        return this.Ok(new { status = "True", message = "Search Books", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Books Not Available" });
                    }
                }
                else
                {
                    var data =  this.bookBL.GetAllBooks();
                    if (data.Count != 0)
                    {
                        return this.Ok(new { status = "True", message = "All Books", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Books Not Available" });
                    }
                }
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateBookPrice(UpdateBookModel updateBookModel)
        {
            try
            {
                var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (claim == "admin")
                {
                    var data = this.bookBL.UpdateBookPrice(updateBookModel);
                    if (data != null)
                    {
                        return this.Ok(new { status = "True", message = "Book Updated Successfully", data });
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Upate Book" });
                    }
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Sorry, You Are Not Able To Update Book" });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete]
        [Route("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserRole").Value;
                if (claim == "admin")
                {
                    var data = this.bookBL.DeleteBook(bookId);
                    if (data == true)
                    {
                        return this.Ok(new { status = "True", message = "Book Deleted Successfully"});
                    }
                    else
                    {
                        return this.BadRequest(new { status = "False", message = "Failed To Delete Book" });
                    }
                }
                else
                {
                    return this.BadRequest(new { status = "False", message = "Sorry, You Are Not Able To Update Book" });
                }

            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
