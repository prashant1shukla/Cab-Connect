using Xunit;
using Moq;
using Assigmnent_2.Models;
using Assigmnent_2.Services;
using Assigmnent_2.Services.IServices;
using Assginment_2_Tests.Services.TestData;
using Assigmnent_2.Data;
using Assigmnent_2.Data.IData;

namespace Assginment_2_Tests.Services
{
    public class UserServiceTests
    {
        [Theory]
        [MemberData(nameof(UserServiceTestData.GetUserByUsernameTestData), MemberType = typeof(UserServiceTestData))]
        public void GetUserByUsername_ReturnsExpectedUser(string username, UserModel expectedUser)
        {
            // Arrange
            var userService = new UserService();
            if (expectedUser != null)
            {
                UserDataStore.Users.Add(expectedUser);
            }

            // Act
            var result = userService.GetUserByUsername(username);

            // Assert
            Assert.Equal(expectedUser, result);
        }

        [Theory]
        [MemberData(nameof(UserServiceTestData.RegisterUserTestData), MemberType = typeof(UserServiceTestData))]
        public void RegisterUser_WithTestData_ReturnsExpectedResult(UserModel newUser, bool expected)
        {
            // Arrange
            var userService = new UserService();

            // Act
            var result = userService.RegisterUser(newUser);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
