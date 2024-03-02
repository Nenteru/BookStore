using BookStore.API.Contracts;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetListBooks();

            var response = books.Select(x => new BooksResponse(x.Id, x.Title, x.Description, x.Price)).ToList();

            return Ok(response);
        }
    }
}
