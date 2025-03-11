using ElsherbinyTasks02.API.DTO.Requests;
using ElsherbinyTasks02.API.Models;
using ElsherbinyTasks02.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElsherbinyTasks02.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        private readonly BookService _bookService;

        public AuthorsController(AuthorService authorService,
                                 BookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        // Add an Author 
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] CreateAuthorRequest request)
        {
            var author = new Author
            {
                Name = request.Name,
                BirthDate = request.BirthDate
            };

            await _authorService.AddAsync(author);
            return Created();
        }

        // Retreive All Authors 

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);

        }


        // Get Author by specific Id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author is null)
                return NotFound($"There is no author with this ID {id}");
            return Ok();
        }



        // Delete Author by specific Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelById(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author is null)
                return NotFound($"There is no author with this ID {id}");

            var isDeleted = await _authorService.DeleteAsync(id);
            if (isDeleted)
                return NoContent(); // HTTP 204 No Content

            return StatusCode(500, "An error occurred while deleting the author."); // HTTP 500 Internal Server Error
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, UpdateAuthorRequest request)
        {
            return NoContent();
        }





        //Get /authors/1/books
        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAuthorBooks(Guid id)
        {

            var books = await _authorService.GetAuthorBooksAsync(id);

            if (!books.Any())
                return NotFound($"No books found for author with ID {id}");

            return Ok(books);


        }

        //GET /authors/1/books/1

        [HttpGet("{id}/books/{bookId}")]
        public async Task<IActionResult> GetAuthorBook(Guid id, Guid bookId)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author is null)
                return NotFound("Author not found");

            var book = await _bookService.GetByIdAsync(bookId);
            if (book is null)
                return NotFound("Book not found");

            if (!book.AuthorId.Equals(id))
                return BadRequest("This book does not belong to the specified author");

            return Ok(book);
        }


        // DELETE /authors/1/books/1
        // Delete a specific book by ID for a specific author.

        [HttpDelete("{id}/books/{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid id, Guid bookId)
        {


            return Ok();
        }



        [HttpPost("{id}/books")]
        public async Task<IActionResult> AddBook(Guid id, [FromBody] CreateBookRequest request)
        {


            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null)
                    return NotFound($"Author with ID {id} not found");



                var book = new Book
                {
                    title = request.title,
                    AuthorId = id,
                    publishedDate = request.publishedDate
                };

                await _bookService.AddAsync(book);


                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }





        }

        // PUT /authors/:authorId/books/:bookId
        // Update a specific book by ID for a specific author.
        [HttpPut("{id}/books/{booksId}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookRequest request, Guid booksId)
        {
            return NoContent();
        }


    }
}