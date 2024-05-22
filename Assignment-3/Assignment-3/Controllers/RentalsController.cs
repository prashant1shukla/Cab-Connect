using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    /// <summary>
    /// Controller for managing movie rentals and their associated operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        /// <summary>
        /// Rents a movie to a customer by specifying customer ID and movie ID.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <param name="movieId">The ID of the movie.</param>
        [HttpPost("{customerId}/movies/{movieId}")]
        public IActionResult RentMovieToCustomer(int customerId, int movieId)
        {
            var responseDTO = _rentalService.RentMovieToCustomer(customerId, movieId);
            if (responseDTO == null)
            {
                return NotFound("Customer or Movie not found");
            }
            return Ok(responseDTO);
        }

        /// <summary>
        /// Rents a movie to a customer by specifying movie title and customer username.
        /// </summary>
        /// <param name="RentalByTitleAndUsernameRequestDTO">The data of the movie title and customer's username to be added.</param>
        [HttpPost("rentByTitleAndUsername")]
        public IActionResult RentMovieToCustomerByTitleAndUsername( RentalByTitleAndUsernameRequestDTO requestDTO)
        {
            if (requestDTO == null)
            {
                return BadRequest("Request body cannot be null");
            }

            var responseDTO = _rentalService.RentMovieToCustomerByTitleAndUsername(requestDTO.MovieTitle, requestDTO.Username);
            if (responseDTO == null)
            {
                return NotFound("Customer or Movie not found");
            }
            return Ok(responseDTO);
        }
    }
}
