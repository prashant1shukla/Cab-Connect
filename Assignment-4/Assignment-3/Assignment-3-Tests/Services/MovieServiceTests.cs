using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Services
{
    public class MovieServiceTests
    {
        [Fact]
        public void AddMovie_PositiveTest()
        {
            // Arrange
            var movieRequestDTO = new MovieRequestDTO
            {
                Title = "Test Movie",
                RentalPrice = 6
            };

            var mockDbSet = new Mock<DbSet<Movie>>();
            var movie = new Movie
            {
                Title = movieRequestDTO.Title,
                RentalPrice = movieRequestDTO.RentalPrice
            };
            mockDbSet.Setup(m => m.Add(It.IsAny<Movie>())).Callback<Movie>(m => movie = m);

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.AddMovie(movieRequestDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movie.Title, result.Title);
            Assert.Equal(movie.RentalPrice, result.RentalPrice);
        }

        [Fact]
        public void AddMovie_NegativeTest()
        {
            // Arrange
            var movieRequestDTO = new MovieRequestDTO
            {
                Title = "Test Movie",
                RentalPrice = 5
            };

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies.Add(It.IsAny<Movie>())).Throws(new Exception("Failed to add movie"));

            var movieService = new MovieService(mockContext.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => movieService.AddMovie(movieRequestDTO));
        }

        [Fact]
        public void GetAllMovies_PositiveTest()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "Movie 1", RentalPrice = 7 },
                new Movie { Id = 2, Title = "Movie 2", RentalPrice = 8 }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Movie>>();
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.Provider);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.Expression);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.ElementType);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.GetAllMovies();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetAllMovies_NegativeTest()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<Movie>>();
            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Throws(new Exception("Failed to retrieve movies"));

            var movieService = new MovieService(mockContext.Object);

            // Act & Assert
            Assert.Throws<Exception>(() => movieService.GetAllMovies());
        }

        [Fact]
        public void GetMovieById_PositiveTest()
        {
            // Arrange
            var movie = new Movie { Id = 1, Title = "Movie 1", RentalPrice = 7 };
            var movies = new List<Movie> { movie };

            var mockDbSet = new Mock<DbSet<Movie>>();
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.GetMovieById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movie.Id, result.Id);
            Assert.Equal(movie.Title, result.Title);
            Assert.Equal(movie.RentalPrice, result.RentalPrice);
        }

        [Fact]
        public void GetMovieById_NegativeTest()
        {
            // Arrange
            var movies = new List<Movie>(); // Empty movie list
            var mockDbSet = new Mock<DbSet<Movie>>();
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.GetMovieById(1);

            // Assert
            Assert.Null(result); // Assert that null is returned when movie is not found
        }



        [Fact]
        public void GetMovieByTitle_PositiveTest()
        {
            // Arrange
            var movie = new Movie { Id = 1, Title = "Movie 1", RentalPrice = 7 };
            var movies = new List<Movie> { movie };

            var mockDbSet = new Mock<DbSet<Movie>>();
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.GetMovieByTitle("Movie 1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(movie.Id, result.Id);
            Assert.Equal(movie.Title, result.Title);
            Assert.Equal(movie.RentalPrice, result.RentalPrice);
        }

        [Fact]
        public void GetMovieByTitle_NegativeTest()
        {
            // Arrange
            var movies = new List<Movie>(); // Empty movie list
            var mockDbSet = new Mock<DbSet<Movie>>();
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(movies.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(movies.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(movies.GetEnumerator());

            var mockContext = new Mock<IEF_DataContext>();
            mockContext.Setup(m => m.Movies).Returns(mockDbSet.Object);

            var movieService = new MovieService(mockContext.Object);

            // Act
            var result = movieService.GetMovieByTitle("Movie 1");

            // Assert
            Assert.Null(result); // Assert that null is returned when movie is not found
        }



    }
}
