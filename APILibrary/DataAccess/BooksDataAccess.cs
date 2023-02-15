using APILibrary.DataAccess.Internal;
using APILibrary.Models;

namespace APILibrary.DataAccess
{
    /// <summary>
    /// The books data access.
    /// </summary>
    public class BooksDataAccess : IBooksDataAccess
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksDataAccess"/> class.
        /// </summary>
        /// <param name="sqlDataAccess">The sql data access.</param>
        public BooksDataAccess(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        /// <summary>
        /// Gets the all books.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<List<BookModel>> GetAllBooks()
        {
            
            return await _sqlDataAccess.LoadDataAsync<BookModel, dynamic>("dbo.spBooks_GetBooks", new { }, "BooksDB");
        }

        /// <summary>
        /// Inserts the book.
        /// </summary>
        /// <param name="bookToInsert">The book to insert.</param>
        public void InsertBook(BookModel bookToInsert)
        {

            _sqlDataAccess.SaveData("dbo.spBooks_InsertBook", new { bookToInsert.BookId,bookToInsert.Title,bookToInsert.AuthorFirstName,bookToInsert.AuthorLastName,bookToInsert.Genre,bookToInsert.Price,bookToInsert.PublishDate,bookToInsert.Description }, "BooksDB");
        }
    }
}