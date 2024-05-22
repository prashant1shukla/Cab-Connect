using Assignment_3.DTO.ResponseDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

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

        [HttpPost("movies/{movieTitle}/customers/{username}")]
        public IActionResult RentMovieToCustomerByTitleAndUsername(string movieTitle, string username)
        {
            var responseDTO = _rentalService.RentMovieToCustomerByTitleAndUsername(movieTitle, username);
            if (responseDTO == null)
            {
                return NotFound("Customer or Movie not found");
            }
            return Ok(responseDTO);
        }
    }
}
