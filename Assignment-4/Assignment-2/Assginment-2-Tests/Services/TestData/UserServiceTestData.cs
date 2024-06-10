using Assigmnent_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Services.TestData
{
    public static class UserServiceTestData
    {
        public static IEnumerable<object[]> GetUserByUsernameTestData =>
            new List<object[]>
            {
                // Positive test case: Test data for an existing user
                new object[] { "existingUser", new UserModel { Username = "existingUser", Password = "password" } },

                // Positive test case: Test data for a non-existing user
                new object[] { "nonExistingUser", null }
            };

        public static IEnumerable<object[]> RegisterUserTestData =>
            new List<object[]>
            {
                // Positive test case: Registering a new user with unique username
                new object[] { new UserModel { Username = "uniqueUser", Password = "password" }, true },

                // Negative test case: Registering a user with an existing username
                new object[] { new UserModel { Username = "existingUser", Password = "password" }, false }
            };
    }
}
