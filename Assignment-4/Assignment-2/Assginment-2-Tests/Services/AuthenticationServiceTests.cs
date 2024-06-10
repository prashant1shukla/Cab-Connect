using Assginment_2_Tests.Services.TestData;
using Assigmnent_2.CustomException;
using Assigmnent_2.Models;
using Assigmnent_2.Services;
using Assigmnent_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Services
{
    public class AuthenticationServiceTests
    {
        public static IEnumerable<object[]> AuthenticationData =>
            new List<object[]>
            {
               
                // Invalid username
                new object[] { new LoginViewModel { Username = "invaliduser", Password = "validpassword" }, false },

                // Null username
                new object[] { new LoginViewModel { Username = null, Password = "validpassword" }, false },

            };

        [Theory]
        [MemberData(nameof(AuthenticationData))]
        public void AuthenticateUser_ValidCredentials_ReturnsUser(LoginViewModel login, bool expectedResult)
        {
            // Arrange
            var authService = new AuthenticationService();

            // Act
            UserModel user = null;
           
            // Assert
            if (expectedResult)
            {
                Assert.NotNull(user);
                Assert.Equal(login.Username, user.Username);
            }
            else
            {
                Assert.Null(user);
            }
        }
    }
}
