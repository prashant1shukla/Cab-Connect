using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Controllers.TestData
{
    public class MoviesControllerTestData
    {
        public static IEnumerable<object[]> AddMovieTestData()
        {
            // Positive test
            yield return new object[]{ new MovieRequestDTO { Title = "Test Movie", RentalPrice = 10.5m },true};
            // Negative test
            yield return new object[]{ new MovieRequestDTO { Title = null, RentalPrice = 10.5m },false };
        }

        public static IEnumerable<object[]> GetAllMoviesTestData()
        {
            // Empty list of movies
            yield return new object[]{new List<MovieResponseDTO>(),};

            // Positive test with populated list
            yield return new object[]{
                new List<MovieResponseDTO>{
                    new MovieResponseDTO { Id = 1, Title = "Test Movie 1", RentalPrice = 10.5m },
                    new MovieResponseDTO { Id = 2, Title = "Test Movie 2", RentalPrice = 9.99m }
                }
            };

            // Negative test with null list
            yield return new object[]{(List<MovieResponseDTO>)null};
        }

        public static IEnumerable<object[]> GetMovieByIdTestData()
        {
            // Positive test with valid movie
            yield return new object[]{1,new MovieResponseDTO()};

            // Negative test with null movie response and invladi id 0
            yield return new object[]{0, null };
        }

        public static IEnumerable<object[]> GetMovieByTitleTestData()
        {
            // Positive test with valid movie
            yield return new object[]{"Test Movie", new MovieResponseDTO() };

            // Negative test with null movie response
            yield return new object[]{ null,  null };
        }
    }
}
