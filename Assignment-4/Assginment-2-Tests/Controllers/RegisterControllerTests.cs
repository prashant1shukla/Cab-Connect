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
    public class RegisterControllerTests
    {
        [Theory]
        [MemberData(nameof(RegisterControllerTestData.PositiveRegisterTestData), MemberType = typeof(RegisterControllerTestData))]
        public void Register_PositiveTest(UserModel userModel)
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.RegisterUser(userModel)).Returns(true); // Assuming registration successful
            var controller = new RegisterController(userServiceMock.Object);

            // Act
            var result = controller.Register(userModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("User registered successfully", okResult.Value);
        }

        [Theory]
        [MemberData(nameof(RegisterControllerTestData.NegativeRegisterTestData), MemberType = typeof(RegisterControllerTestData))]
        public void Register_NegativeTest(UserModel userModel)
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.RegisterUser(userModel)).Returns(false); // Assuming registration failed
            var controller = new RegisterController(userServiceMock.Object);

            // Act
            var result = controller.Register(userModel);

            // Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result);
            Assert.Equal("Username already exists", conflictResult.Value);
        }
    }
}
