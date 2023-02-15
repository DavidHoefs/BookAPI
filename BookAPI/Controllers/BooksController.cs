using APILibrary.DataAccess;
using APILibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    /// <summary>
    /// The books controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController
    {
        private readonly IBooksDataAccess _booksData;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="booksData">The books data.</param>
        public BooksController(IBooksDataAccess booksData)
        {
            _booksData = booksData;
        }

        /// <summary>
        /// Gets the books.
        /// </summary>
        /// <returns>A Task.</returns>
        [HttpGet]
        public async Task<List<BookModel>> GetBooks()
        {
            return await _booksData.GetAllBooks();
        }

        [HttpPost]
        [Route("Insert")]
        [AllowAnonymous]
        public void InsertBook(BookModel book)
        {
            _booksData.InsertBook(book);
        }
    }
}
