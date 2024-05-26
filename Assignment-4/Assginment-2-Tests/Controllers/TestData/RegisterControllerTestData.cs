using Assigmnent_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Controllers.TestData
{
    public static class RegisterControllerTestData
    {
        public static IEnumerable<object[]> PositiveRegisterTestData()
        {
            yield return new object[] { new UserModel { Username = "NewUser", Password = "Password" } }; // Positive case: New username
        }

        public static IEnumerable<object[]> NegativeRegisterTestData()
        {
            yield return new object[] { new UserModel { Username = "ExistingUser", Password = "Password" } }; // Negative case: Existing username
        }
    }
}
