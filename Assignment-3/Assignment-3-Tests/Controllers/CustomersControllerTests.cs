using Assignment_3.Controllers;
using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Services.IServices;
using Assignment_3_Tests.Controllers.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Controllers
{
    public class CustomersControllerTests
    {
        [Theory]
        [MemberData(nameof(CustomersControllerTestData.AddCustomerTestData), MemberType = typeof(CustomersControllerTestData))]
        public void AddCustomer_Test(CustomerRequestDTO customerRequestDTO, bool expectedResult)
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            if (expectedResult)
            {
                customerServiceMock.Setup(service => service.AddCustomer(customerRequestDTO)).Returns(new CustomerResponseDTO());
            }
            else
            {
                customerServiceMock.Setup(service => service.AddCustomer(customerRequestDTO)).Returns((CustomerResponseDTO)null);
            }
            var controller = new CustomersController(customerServiceMock.Object);

            // Act
            var result = controller.AddCustomer(customerRequestDTO);

            // Assert
            if (expectedResult)
            {
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<BadRequestObjectResult>(result);
                var badRequestResult = result as BadRequestObjectResult;
                Assert.Equal("Username cannot be null or empty.", badRequestResult.Value);
            }
        }

        [Theory]
        [MemberData(nameof(CustomersControllerTestData.GetCustomersForMovieTestData), MemberType = typeof(CustomersControllerTestData))]
        public void GetCustomersForMovie_Test(int movieId, List<CustomersForMovieResponseDTO> customers)
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(service => service.GetCustomersForMovie(movieId)).Returns(customers);
            var controller = new CustomersController(customerServiceMock.Object);

            // Act
            var result = controller.GetCustomersForMovie(movieId);

            // Assert
            if (customers.Any())
            {
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Theory]
        [MemberData(nameof(CustomersControllerTestData.GetMoviesForCustomerTestData), MemberType = typeof(CustomersControllerTestData))]
        public void GetMoviesForCustomer_Test(int customerId, List<MoviesForCustomerResponseDTO> movies)
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(service => service.GetMoviesForCustomer(customerId)).Returns(movies);
            var controller = new CustomersController(customerServiceMock.Object);

            // Act
            var result = controller.GetMoviesForCustomer(customerId);

            // Assert
            if (movies.Any())
            {
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<NotFoundObjectResult>(result);
            }
        }

        [Theory]
        [MemberData(nameof(CustomersControllerTestData.GetTotalCostForCustomerTestData), MemberType = typeof(CustomersControllerTestData))]
        public void GetTotalCostForCustomer_Test(int customerId, decimal totalCost)
        {
            // Arrange
            var customerServiceMock = new Mock<ICustomerService>();
            customerServiceMock.Setup(service => service.GetTotalCostForCustomer(customerId)).Returns(totalCost);
            var controller = new CustomersController(customerServiceMock.Object);

            // Act
            var result = controller.GetTotalCostForCustomer(customerId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
