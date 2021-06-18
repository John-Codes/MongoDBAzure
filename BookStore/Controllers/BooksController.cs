using BookStore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices1;
        public BooksController(IBookServices bookServices)
        {
            bookServices1 = bookServices;
            
        }

      [HttpGet]
      public IActionResult GetBooks()
        {
            return Ok(bookServices1.GetBooks());

        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(string id)
        {
            return Ok(bookServices1.GetBook(id));
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            bookServices1.AddBook(book);
            
            return CreatedAtRoute("GetBook", new { id = book.id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            bookServices1.DeleteBook(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            return Ok(bookServices1.UppdateBook(book));
        }
        
    }
}
