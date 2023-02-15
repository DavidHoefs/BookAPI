using APILibrary.Models;

namespace APILibrary.DataAccess;

public interface IBooksDataAccess
{
    /// <summary>
    /// Gets the all books.
    /// </summary>
    /// <returns>A Task.</returns>
    Task<List<BookModel>> GetAllBooks();

    void InsertBook(BookModel bookToInsert);
}