public class Book
{
    public string BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int CopiesAvailable { get; set; }

    public Book(string bookId, string title, string author, int copiesAvailable)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        CopiesAvailable = copiesAvailable;
    }
}
