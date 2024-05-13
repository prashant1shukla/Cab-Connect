using System;
using System.Collections.Generic;

public class User
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public List<Book> BooksIssued { get; set; }

    public User(string userId, string name)
    {
        UserId = userId;
        Name = name;
        BooksIssued = new List<Book>();
    }

    public void IssueBook(Book book)
    {
        BooksIssued.Add(book);
    }

    public void DisplayIssuedBooks()
    {
        Console.WriteLine($"Books issued by {Name}:");
        foreach (var book in BooksIssued)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }

    public void DisplayIssuerName()
    {
        Console.WriteLine($"Issuer name for user {Name}: {Name}");
    }

    public int CalculateFine()
    {
        int totalFine = 0;
        foreach (var book in BooksIssued)
        {
            int daysSinceIssued = (DateTime.Today - DateTime.Today.AddDays(-7)).Days;
            if (daysSinceIssued > 7)
            {
                int fine = (daysSinceIssued - 7) * 10;
                totalFine += fine;
            }
        }
        return totalFine;
    }
}
