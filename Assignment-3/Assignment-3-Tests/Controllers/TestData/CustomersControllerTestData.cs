using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_Tests.Controllers.TestData
{
    public class CustomersControllerTestData
    {
        public static IEnumerable<object[]> AddCustomerTestData()
        {
            // Positive test
            yield return new object[] { new CustomerRequestDTO { Username = "TestUser" }, true };

            // Negative test with null username
            yield return new object[] { new CustomerRequestDTO { Username = null }, false };

            // Negative test with empty username
            yield return new object[] { new CustomerRequestDTO { Username = "" }, false };
        }

        public static IEnumerable<object[]> GetCustomersForMovieTestData()
        {
            // Positive test with populated list
            yield return new object[]{1, new List<CustomersForMovieResponseDTO>{
                new CustomersForMovieResponseDTO { Id = 1, Username = "User1" },
                new CustomersForMovieResponseDTO { Id = 2, Username = "User2" }
            }};

            // Negative test with empty list
            yield return new object[] { 1, new List<CustomersForMovieResponseDTO>() };
        }

        public static IEnumerable<object[]> GetMoviesForCustomerTestData()
        {
            // Positive test with populated list
            yield return new object[]{1, new List<MoviesForCustomerResponseDTO>{
                new MoviesForCustomerResponseDTO { Id = 1, Title = "Movie1", RentalPrice = 10.5m },
                new MoviesForCustomerResponseDTO { Id = 2, Title = "Movie2", RentalPrice = 9.99m }
            }};

            // Negative test with empty list
            yield return new object[] { 1, new List<MoviesForCustomerResponseDTO>() };
        }

        public static IEnumerable<object[]> GetTotalCostForCustomerTestData()
        {
            yield return new object[] { 1, 25.75m }; // Positive test
        }
    }
}
