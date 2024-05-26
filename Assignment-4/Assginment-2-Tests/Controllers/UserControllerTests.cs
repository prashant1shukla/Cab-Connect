using Assginment_2_Tests.Controllers.TestData;
using Assigmnent_2.Controllers;
using Assigmnent_2.Models;
using Assigmnent_2.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assginment_2_Tests.Controllers
{
    public class UserControllerTests
    {
        [Theory]
        [MemberData(nameof(UserControllerTestData.GetUserData), MemberType = typeof(UserControllerTestData))]
        public void GetUser_Test(string username, bool userExists)
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var controller = new UserController(userServiceMock.Object);
            var user = userExists ? new UserModel { Username = username } : null;
            userServiceMock.Setup(service => service.GetUserByUsername(username)).Returns(user);

            // Setting up User.Identity.Name for the controller
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var userPrincipal = new ClaimsPrincipal(identity);
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = userPrincipal }
            };

            // Act
            var result = controller.GetUser();

            // Assert
            if (userExists)
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal(user, okResult.Value);
            }
            else
            {
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal("User not found", notFoundResult.Value);
            }
        }
    }
}
