using BookHomeWorkApi.DTO;
using BookHomeWorkApi.Models;
using BookHomeWorkApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;


namespace BookHomeWorkApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        public IActionResult GetAllBook()
        {           
            return Ok(_bookService.GetAllBook());
        }
        [HttpGet]
        [Route ("{id}")]
        public IActionResult GetBookById(int id)
        {
            var books = _bookService.GetBookById(id);

            if (books is null)
                return NotFound();

            return Ok(books);
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _bookService.Create(book);

            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult BookEdit(int id, [FromBody] BookDTO book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_bookService.Edit(id, book));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            return Ok(_bookService.Delete(id));
        }
    }
}
