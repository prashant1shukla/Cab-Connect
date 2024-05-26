using assignment_1.library.books;
using assignment_1.library.libraryManagement;
using assignment_1.library.users;

namespace Assignment_1_Tests
{
    public class LibraryManagerCalculationTests
    {
        [Theory]
        [MemberData(nameof(TestCalculateFineData))]
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

        public static IEnumerable<object[]> TestCalculateFineData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book[] { new Book("b-1", "Intro C#", "Author-1", 5) }, 0 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book[] { new Book("b-2", "DSA Book", "Author-2", 10) }, 0 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book[] { new Book("b-3", "DevOps Book", "Author-3", 3) }, 0 };
        }

        [Theory]
        [MemberData(nameof(TestCalculateFineNoBooksIssuedData))]
        public void TestCalculateFine_NoBooksIssued(User user, int expectedFine)
        {
            // Arrange
            LibraryManager library = new LibraryManager();

            // Act
            int fine = library.CalculateFine(user);

            // Assert
            Assert.Equal(expectedFine, fine);
        }

        public static IEnumerable<object[]> TestCalculateFineNoBooksIssuedData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), 0 }; // No books issued
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), 0 }; // No books issued
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), 0 }; // No books issued
        }
    }
}
