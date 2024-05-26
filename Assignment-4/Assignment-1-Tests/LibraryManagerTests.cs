using Assignment_1_Tests.TestData;
using assignment_1.library.libraryManagement;
using assignment_1.library.books;
using assignment_1.library.users;
using Xunit;

namespace Assignment_1_Tests
{
    public class LibraryManagerTests
    {
        [Theory]
        [MemberData(nameof(TestCalculateFineData.TestIssueBookData), MemberType = typeof(TestCalculateFineData))]
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

        [Theory]
        [MemberData(nameof(TestCalculateFineData.TestReturnBookData), MemberType = typeof(TestCalculateFineData))]
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

        [Theory]
        [MemberData(nameof(TestCalculateFineData.TestIssueBook_NotEnoughCopiesData), MemberType = typeof(TestCalculateFineData))]
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
    }
}
