using BookService.Models;
using BookService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;

        public BooksController(IBooksService _booksService)
        {
            booksService = _booksService;
        }

        [HttpGet("getbookbyid")]
        public IActionResult GetBookById(int id)
        {
            var book = booksService.GetBookById(id);
            if (book != null)
            {
                return new OkObjectResult(book);
            }
            return new BadRequestResult();
        }

        [HttpGet("getallbooks")]
        public IActionResult GetAllBooks()
        {
            return new OkObjectResult(booksService.GetAllBooks());
        }

        [HttpGet("getbooksbyauthor")]
        public IActionResult GetBooksByAuthor(string authorFullName)
        {
            var books = booksService.GetBooksByAuthor(authorFullName);
            return new OkObjectResult(books);
        }

        [HttpGet("getbooksbygenre")]
        public IActionResult GetBooksByGenre(string genre)
        {
            var books = booksService.GetBooksByGenre(genre);
            return new OkObjectResult(books);
        }
    }
}