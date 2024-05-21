using Assignment_3.DTO.ResponseDTO;
using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    public class RentalsController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public RentalsController(EF_DataContext context)
        {
            _context = context;
        }

        // 6. Rent a movie to a customer by giving movie id and customer id
        [HttpPost("{customerId}/movies/{movieId}")]
        public IActionResult RentMovieToCustomer(int customerId, int movieId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }

            var rental = new Rental
            {
                CustomerId = customerId,
                MovieId = movieId,
                RentalDate = DateTime.UtcNow
                // Other rental properties
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            var responseDTO = new RentalResponseDTO
            {
                CustomerId = rental.CustomerId,
                MovieId = rental.MovieId,
                RentalDate = rental.RentalDate
                // Map other properties to response DTO
            };

            return Ok(responseDTO);
        }

        // 7. Rent a movie to a customer by giving movie title and customer username
        [HttpPost("movies/{movieId}/customers/{username}")]
        public IActionResult RentMovieToCustomerByTitleAndUsername(int movieId, string username)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Username == username);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }

            var rental = new Rental
            {
                CustomerId = customer.Id,
                MovieId = movieId,
                RentalDate = DateTime.UtcNow
                // Other rental properties
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            var responseDTO = new RentalResponseDTO
            {
                CustomerId = rental.CustomerId,
                MovieId = rental.MovieId,
                RentalDate = rental.RentalDate
                // Map other properties to response DTO
            };

            return Ok(responseDTO);
        }
    }
}
