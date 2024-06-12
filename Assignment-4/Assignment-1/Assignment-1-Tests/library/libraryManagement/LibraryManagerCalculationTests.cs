using Assignment_1_Tests.TestData;
using assignment_1.library.libraryManagement;
using assignment_1.library.books;
using assignment_1.library.users;
using Xunit;

namespace Assignment_1_Tests
{
    public class LibraryManagerCalculationTests
    {
        [Theory]
        [MemberData(nameof(LibraryManagerCalculationTestData.TestCalculateFineData), MemberType = typeof(LibraryManagerCalculationTestData))]
        public void TestCalculateFine_ValidData(User user, Book[] books, int expectedFine)
        {
            // Arrange
            LibraryManager library = new LibraryManager();
            foreach (var book in books)
            {
                library.AddBook(book);
                library.IssueBook(user, book);
            }

            // Act
            int fine = library.CalculateFine(user);

            // Assert
            Assert.Equal(expectedFine, fine);
        }

        [Theory]
        [MemberData(nameof(LibraryManagerCalculationTestData.TestCalculateFineNoBooksIssuedData), MemberType = typeof(LibraryManagerCalculationTestData))]
        public void TestCalculateFine_NoBooksIssued(User user, int expectedFine)
        {
            // Arrange
            LibraryManager library = new LibraryManager();

            // Act
            int fine = library.CalculateFine(user);

            // Assert
            Assert.Equal(expectedFine, fine);
        }
    }
}
