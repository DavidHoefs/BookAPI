using APILibrary.DataAccess.Internal;
using APILibrary.Models;

namespace APILibrary.DataAccess
{
    /// <summary>
    /// The books data access.
    /// </summary>
    public class BooksDataAccess
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
    }
}