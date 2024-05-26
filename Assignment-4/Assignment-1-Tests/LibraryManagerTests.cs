using assignment_1.library.books;
using assignment_1.library.libraryManagement;
using assignment_1.library.users;

namespace Assignment_1_Tests
{
    public class LibraryManagerTests
    {
        [Theory]
        [MemberData(nameof(TestIssueBookData))]
        //It includes different combinations of users, books, and expected copies available after issuing
        public void TestIssueBook(User user, Book book, int expectedCopiesAvailable)
        {
            // Arrange
            LibraryManager library = new LibraryManager();
            library.AddUser(user);
            library.AddBook(book);

            // Act
            library.IssueBook(user, book);

            // Assert
            Assert.Equal(expectedCopiesAvailable, book.CopiesAvailable);
        }

        public static IEnumerable<object[]> TestIssueBookData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 5), 4 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 10), 9 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 3), 2 };
        }

        [Theory]
        [MemberData(nameof(TestReturnBookData))]
        //Verifies whether the number of copies available is updated correctly after returning a book
        public void TestReturnBook(User user, Book book, int expectedCopiesAvailable)
        {
            // Arrange
            LibraryManager library = new LibraryManager();
            library.AddUser(user);
            library.AddBook(book);
            library.IssueBook(user, book);

            // Act
            library.ReturnBook(user, book);

            // Assert
            // Verify the number of copies available for the book
            Assert.Equal(expectedCopiesAvailable, book.CopiesAvailable);

            // Verify that the book is removed from the user's list of issued books
            Assert.DoesNotContain(book, user.BooksIssued);
        }

        public static IEnumerable<object[]> TestReturnBookData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 5), 5 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 10), 10 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 3), 3 };
        }

        [Theory]
        [MemberData(nameof(TestIssueBook_NotEnoughCopiesData))]
        //Verifies whether the number of copies available remains unchanged(still 0) after attempting to issue the book
        public void TestIssueBook_NotEnoughCopies(User user, Book book)
        {
            // Arrange
            LibraryManager library = new LibraryManager();
            library.AddUser(user);
            library.AddBook(book);

            // Act
            library.IssueBook(user, book);

            // Assert
            // CopiesAvailable should remain unchanged (still 0)
            Assert.Equal(0, book.CopiesAvailable);
        }

        public static IEnumerable<object[]> TestIssueBook_NotEnoughCopiesData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 0) };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 0) };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 0) };
        }

    }
}

