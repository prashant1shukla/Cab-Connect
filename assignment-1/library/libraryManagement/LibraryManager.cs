using System;
using System.Collections.Generic;

public class LibraryManager
{
    private List<User> users;
    private List<Book> books;
    
    public LibraryManager()
    {
        users = new List<User>();
        books = new List<Book>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void IssueBook(User user, Book book)
    {
        if (user.BooksIssued.Count >= 3 && user.GetType() == typeof(Student))
        {
            Console.WriteLine("Students can only issue up to 3 books at a time.");
            return;
        }
        else if (user.BooksIssued.Count >= 10 && user.GetType() == typeof(Teacher))
        {
            Console.WriteLine("Teachers can only issue up to 10 books at a time.");
            return;
        }

        if (book.CopiesAvailable > 0)
        {
            user.IssueBook(book);
            book.CopiesAvailable--;
            Console.WriteLine($"{user.Name} has successfully issued {book.Title}.");
        }
        else
        {
            Console.WriteLine("Sorry, the book is not available.");
        }
    }

    public void ReturnBook(User user, Book book)
    {
        if (user.BooksIssued.Contains(book))
        {
            user.BooksIssued.Remove(book);
            book.CopiesAvailable++;
            Console.WriteLine($"{user.Name} has successfully returned {book.Title}.");
        }
        else
        {
            Console.WriteLine("You have not issued this book.");
        }
    }

    public void DisplayUserBooks(User user)
    {
        user.DisplayIssuedBooks();
    }

    public void DisplayIssuerName(User user)
    {
        user.DisplayIssuerName();
    }

    public void DisplayIssuees(Book book)
    {
        Console.WriteLine($"List of issuees for {book.Title}:");
        foreach (var user in users)
        {
            if (user.BooksIssued.Contains(book))
            {
                Console.WriteLine(user.Name);
            }
        }
    }

    public int CalculateFine(User user)
    {
        return user.CalculateFine();
    }
}
