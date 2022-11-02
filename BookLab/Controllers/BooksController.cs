using BookLab.Models;
using BookLab.Models.Dto;
using BookRecord.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBookRepository _bookRepository;    
        public BooksController(IBookRepository bookRepository,ILogger<BooksController> logger)
        {
            _bookRepository = bookRepository; 
            _logger = logger;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBook()
        {
            _logger.LogInformation("about the method ");
            try
            {
                IEnumerable<BookDto> abc = await _bookRepository.GetBooks();
                return Ok(abc); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> RetriveBooks(int id )
        {
            try
            {
                var result = await _bookRepository.GetBookFromId(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");


            }
        }


        [HttpPost]
        public async  Task<ActionResult<Book>> AddNewBook(Book book)
        {
            try
            {
                if (book == null)
                    return BadRequest();

                var result=await _bookRepository.AddBook(book); 
                return Ok(result);  



            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error creating new employee record");
            }
        }

        
    }
}
