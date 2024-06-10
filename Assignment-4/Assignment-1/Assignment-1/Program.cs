using System;

class Program
{
    static void Main()
    {
        LibraryManager library = new LibraryManager();

        Student student = new Student("id-1", "Prashant Shukla", "st-1");
        Teacher teacher = new Teacher("id-2", "Piyush", "t-1", "Maths");
        Admin admin = new Admin("id-3", "Admin User", "admin-1", "Administrator");

        library.AddUser(student);
        library.AddUser(teacher);
        library.AddUser(admin);

        Book book1 = new Book("b-1", "Intro C# ", "Author-1", 5);
        Book book2 = new Book("b-2", "DSA Book", "Author-2", 10);
        Book book3 = new Book("b-3", "DevOps Book", "Author-3", 3);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        // Issuing books
        library.IssueBook(student, book1);
        library.IssueBook(student, book2);
        library.IssueBook(teacher, book3);

        // Displaying issued books
        library.DisplayUserBooks(student);
        library.DisplayUserBooks(teacher);

        // Displaying issuer's name
        library.DisplayIssuerName(student);
        library.DisplayIssuerName(teacher);

        // Displaying issuee list for a book
        library.DisplayIssuees(book1);

        // Returning books
        library.ReturnBook(student, book1);

        // Calculating fine
        int studentFine = library.CalculateFine(student);
        int teacherFine = library.CalculateFine(teacher);

        Console.WriteLine($"Fine for student {student.Name}: {studentFine}");
        Console.WriteLine($"Fine for teacher {teacher.Name}: {teacherFine}");
    }
}
