using assignment_1.library.books;
using assignment_1.library.users;
using System.Collections.Generic;

namespace Assignment_1_Tests.TestData
{
    public class LibraryManagerCalculationTestData
    {
        public static IEnumerable<object[]> TestCalculateFineData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book[] { new Book("b-1", "Intro C#", "Author-1", 5) }, 0 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book[] { new Book("b-2", "DSA Book", "Author-2", 10) }, 0 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book[] { new Book("b-3", "DevOps Book", "Author-3", 3) }, 0 };
        }

        public static IEnumerable<object[]> TestCalculateFineNoBooksIssuedData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), 0 }; // No books issued
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), 0 }; // No books issued
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), 0 }; // No books issued
        }
    }
}
