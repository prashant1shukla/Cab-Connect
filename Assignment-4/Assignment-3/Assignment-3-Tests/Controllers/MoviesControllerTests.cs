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
using Xunit;

namespace Assignment_3_Tests.Controllers
{
    public class MoviesControllerTests
    {
        [Theory]
        [MemberData(nameof(MoviesControllerTestData.AddMovieTestData), MemberType = typeof(MoviesControllerTestData))]
        public void AddMovie_Test(MovieRequestDTO movieRequestDTO, bool expectedResult)
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            if (expectedResult)
            {
                movieServiceMock.Setup(service => service.AddMovie(movieRequestDTO)).Returns(new MovieResponseDTO());
            }
            else
            {
                movieServiceMock.Setup(service => service.AddMovie(movieRequestDTO)).Returns((MovieResponseDTO)null);
            }
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.AddMovie(movieRequestDTO);

            // Assert
            if (expectedResult)
            {
                Assert.IsType<OkObjectResult>(result);
            }
            else
            {
                Assert.IsType<BadRequestResult>(result);
            }
        }

        [Theory]
        [MemberData(nameof(MoviesControllerTestData.GetAllMoviesTestData), MemberType = typeof(MoviesControllerTestData))]
        public void GetAllMovies_Test(List<MovieResponseDTO> movies)
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(service => service.GetAllMovies()).Returns(movies);
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.GetAllMovies();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [MemberData(nameof(MoviesControllerTestData.GetMovieByIdTestData), MemberType = typeof(MoviesControllerTestData))]
        public void GetMovieById_Test(int movieId, MovieResponseDTO movieResponse)
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(service => service.GetMovieById(movieId)).Returns(movieResponse);
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.GetMovieById(movieId);

            // Assert
            if (movieResponse == null)
            {
                Assert.IsType<NotFoundResult>(result);
            }
            else
            {
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var responseDTO = Assert.IsType<MovieResponseDTO>(okObjectResult.Value);
                Assert.Equal(movieResponse.Id, responseDTO.Id);
                // Add more assertions if needed
            }
        }

        [Theory]
        [MemberData(nameof(MoviesControllerTestData.GetMovieByTitleTestData), MemberType = typeof(MoviesControllerTestData))]
        public void GetMovieByTitle_Test(string title, MovieResponseDTO movieResponse)
        {
            // Arrange
            var movieServiceMock = new Mock<IMovieService>();
            movieServiceMock.Setup(service => service.GetMovieByTitle(title)).Returns(movieResponse);
            var controller = new MoviesController(movieServiceMock.Object);

            // Act
            var result = controller.GetMovieByTitle(title);

            // Assert
            if (movieResponse == null)
            {
                Assert.IsType<NotFoundResult>(result);
            }
            else
            {
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var responseDTO = Assert.IsType<MovieResponseDTO>(okObjectResult.Value);
                Assert.Equal(movieResponse.Id, responseDTO.Id);
            }
        }
    }
}
