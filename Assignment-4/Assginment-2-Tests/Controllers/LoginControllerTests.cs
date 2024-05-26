using Assginment_2_Tests.Controllers.TestData;
using Assigmnent_2.Controllers;
using Assigmnent_2.Models;
using Assigmnent_2.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Controllers
{
    public class LoginControllerTests
    {
        
        [Theory]
        [MemberData(nameof(LoginControllerTestData.InvalidLoginData), MemberType = typeof(LoginControllerTestData))]
        public void Login_InvalidCredentials_ReturnsUnauthorizedObjectResult(LoginModel loginModel)
        {
            // Arrange
            var authServiceMock = new Mock<IAuthenticationService>();
            var tokenServiceMock = new Mock<ITokenService>();

            var controller = new LoginController(authServiceMock.Object, tokenServiceMock.Object);

            authServiceMock.Setup(service => service.AuthenticateUser(loginModel)).Returns((UserModel)null);

            // Act
            var result = controller.Login(loginModel);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Invalid username or password", unauthorizedResult.Value);
        }
    }
}
