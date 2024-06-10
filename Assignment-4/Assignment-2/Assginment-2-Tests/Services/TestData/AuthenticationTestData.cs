using Assigmnent_2.Models;
using Assigmnent_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Services.TestData
{
    public class AuthenticationTestData
    {
        public static IEnumerable<object[]> ValidLoginData()
        {
            var validUser = new UserModel
            {
                Username = "validuser",
                Password = "validpassword"
            };

            yield return new object[] { new LoginViewModel { Username = "validuser", Password = "validpassword" }, validUser };
        }

        public static IEnumerable<object[]> InvalidUsernameData()
        {
            yield return new object[] { new LoginViewModel { Username = "invaliduser", Password = "validpassword" } };
        }

        public static IEnumerable<object[]> InvalidPasswordData()
        {
            yield return new object[] { new LoginViewModel { Username = "validuser", Password = "invalidpassword" } };
        }

        public static IEnumerable<object[]> NullLoginData()
        {
            yield return new object[] { null };
        }
    }
}
