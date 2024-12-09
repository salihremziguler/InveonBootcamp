using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StackExchange.Redis;
using API.Model;
using API.Exceptions;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDatabase _cache;
        private static List<BookDto> books = new List<BookDto>
        {
            new BookDto { Id = 1, Title = "ABC", Author = "DEF" },
            new BookDto { Id = 2, Title = "123", Author = "456" }
        };


        public BookController(IConnectionMultiplexer redis)
        {
            _cache = redis.GetDatabase();
            
        }



         [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            string cacheKey = $"book:{id}";
            string cachedBook = await _cache.StringGetAsync(cacheKey);


            if (!string.IsNullOrEmpty(cachedBook))
            {

                var bookFromCache = JsonSerializer.Deserialize<BookDto>(cachedBook);
                return Ok(bookFromCache);
            }

            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                throw new BookNotFoundException($" Book with ID {id} not found... ");


            await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(book), TimeSpan.FromMinutes(5));


            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Create([FromBody] BookDto book)
        {

            if (book == null || string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                throw new BadRequestException("Book data is invalid!!");

            books.Add(book);


            string cacheKey = $"book:{book.Id}";
            await _cache.KeyDeleteAsync(cacheKey);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDto updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} not found!!");

            if (updatedBook == null || string.IsNullOrEmpty(updatedBook.Title) || string.IsNullOrEmpty(updatedBook.Author))
                throw new BadRequestException("Updated book data is invalid.");


            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;

            string cacheKey = $"book:{id}";
            await _cache.KeyDeleteAsync(cacheKey);

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                throw new BookNotFoundException($"Book with ID {id} not found!!");

            books.Remove(book);


            string cacheKey = $"book:{id}";
            await _cache.KeyDeleteAsync(cacheKey);


            return NoContent();
        }




        
          [HttpGet("paged")]
        public ActionResult<PagedResponse<BookDto>> GetPaged([FromQuery] PaginationParameters paginationParams)
        {

            var pagedData = books
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToList();


            var totalRecords = books.Count;

            var response = new PagedResponse<BookDto>(pagedData, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);


            return Ok(response);
        }



    }
}
