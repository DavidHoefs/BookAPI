namespace APILibrary.Models
{
    /// <summary>
    /// The book model.
    /// </summary>
    public class BookModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book id.
        /// </summary>
        public string BookId { get; set; }

        /// <summary>
        /// Gets or sets the author first name.
        /// </summary>
        public string AuthorFirstName { get; set; }

        /// <summary>
        /// Gets or sets the author last name.
        /// </summary>
        public string AuthorLastName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the modify date.
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookModel"/> class.
        /// </summary>
        public BookModel(string bookId, string authorFirstName, string authorLastName, string title, string genre, string description)
        {
            BookId = bookId;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            Title = title;
            Genre = genre;
            Description = description;
        }

        public BookModel()
        {
                
        }
    }
}