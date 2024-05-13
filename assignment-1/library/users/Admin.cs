public class Admin : User
{
    public string AdminId { get; set; }
    public string Role { get; set; }

    public Admin(string userId, string name, string adminId, string role) : base(userId, name)
    {
        AdminId = adminId;
        Role = role;
    }

    public void IssueBook(LibraryManager library, User user, Book book)
    {
        library.IssueBook(user, book);
    }

    public void ManageInventory(LibraryManager library, Book book, int copies)
    {
        book.CopiesAvailable += copies;
    }

    public void DisplayInventoryInfo(Book book)
    {
        Console.WriteLine($"Inventory information for {book.Title}:");
        Console.WriteLine($"Book ID: {book.BookId}");
        Console.WriteLine($"Author: {book.Author}");
        Console.WriteLine($"Copies Available: {book.CopiesAvailable}");
    }

    public void DisplayIssueeList(LibraryManager library, Book book)
    {
        library.DisplayIssuees(book);
    }
}
