using assignment_1.library.books;
using assignment_1.library.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Tests.TestData
{
    public class TestCalculateFineData
    {
        public static IEnumerable<object[]> TestIssueBookData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 5), 4 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 10), 9 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 3), 2 };
        }

        public static IEnumerable<object[]> TestReturnBookData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 5), 5 };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 10), 10 };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 3), 3 };
        }

        public static IEnumerable<object[]> TestIssueBook_NotEnoughCopiesData()
        {
            yield return new object[] { new Student("id-1", "Prashant Shukla", "st-1"), new Book("b-1", "Intro C#", "Author-1", 0) };
            yield return new object[] { new Teacher("id-2", "Piyush", "t-1", "Maths"), new Book("b-2", "DSA Book", "Author-2", 0) };
            yield return new object[] { new Admin("id-3", "Admin User", "admin-1", "Administrator"), new Book("b-3", "DevOps Book", "Author-3", 0) };
        }
    }
}
