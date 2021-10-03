using BookHomeWorkApi.DAL;
using BookHomeWorkApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHomeWorkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
       
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBook()
        {
            var books = _context.Books.ToList();
            if (books is null)
                return NotFound();

            return Ok(books);
        }
        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book is null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult BookEdit(int id, [FromBody] Book book)
        {
            var bookDb = _context.Books.FirstOrDefault(m => m.Id == id);

            if (bookDb is null)
                return NotFound();

            book.Id = bookDb.Id;
            book.Name = bookDb.Name;
            book.NumberofPages = bookDb.NumberofPages;
            book.Price = bookDb.Price;
            book.Subject = book.Subject;
            book.Writers = book.Writers;           
            _context.Books.Update(bookDb);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookdb = _context.Books.FirstOrDefault(b => b.Id == id);

            _context.Remove(bookdb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
