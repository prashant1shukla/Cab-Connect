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
    public class RentalsControllerTests
    {
        [Theory]
        [MemberData(nameof(RentalsControllerTestData.RentMovieToCustomerData), MemberType = typeof(RentalsControllerTestData))]
        public void RentMovieToCustomer_PositiveTest(int customerId, int movieId, bool expectedResult)
        {
            // Arrange
            var rentalServiceMock = new Mock<IRentalService>();
            rentalServiceMock.Setup(service => service.RentMovieToCustomer(customerId, movieId))
                             .Returns(expectedResult ? new RentalResponseDTO { CustomerId = customerId, MovieId = movieId, RentalDate = DateTime.UtcNow } : null);
            var controller = new RentalsController(rentalServiceMock.Object);

            // Act
            var result = controller.RentMovieToCustomer(customerId, movieId);

            // Assert
            if (expectedResult)
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                var responseDTO = Assert.IsType<RentalResponseDTO>(okResult.Value);
                Assert.Equal(customerId, responseDTO.CustomerId);
                Assert.Equal(movieId, responseDTO.MovieId);
            }
            else
            {
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal("Customer or Movie not found", notFoundResult.Value);
            }
        }

        [Theory]
        [MemberData(nameof(RentalsControllerTestData.RentMovieToCustomerByTitleAndUsernameData), MemberType = typeof(RentalsControllerTestData))]
        public void RentMovieToCustomerByTitleAndUsername_PositiveTest(string movieTitle, string username, bool expectedResult)
        {
            // Arrange
            var rentalServiceMock = new Mock<IRentalService>();
            rentalServiceMock.Setup(service => service.RentMovieToCustomerByTitleAndUsername(movieTitle, username))
                             .Returns(expectedResult ? new RentalResponseDTO { CustomerId = 1, MovieId = 1, RentalDate = DateTime.UtcNow } : null);
            var controller = new RentalsController(rentalServiceMock.Object);
            var requestDTO = new RentalByTitleAndUsernameRequestDTO { MovieTitle = movieTitle, Username = username };

            // Act
            var result = controller.RentMovieToCustomerByTitleAndUsername(requestDTO);

            // Assert
            if (expectedResult)
            {
                var okResult = Assert.IsType<OkObjectResult>(result);
                var responseDTO = Assert.IsType<RentalResponseDTO>(okResult.Value);
                Assert.Equal(1, responseDTO.CustomerId);
                Assert.Equal(1, responseDTO.MovieId);
            }
            else
            {
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal("Customer or Movie not found", notFoundResult.Value);
            }
        }
    }
}
