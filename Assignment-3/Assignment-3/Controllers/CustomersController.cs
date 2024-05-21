using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public CustomersController(EF_DataContext context)
        {
            _context = context;
        }

        // 5. Add a customer
        [HttpPost]
        public IActionResult AddCustomer(CustomerRequestDTO customerDTO)
        {
            var customer = new Customer
            {
                Username = customerDTO.Username
                // Map other properties from DTO
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var responseDTO = new CustomerResponseDTO
            {
                Id = customer.Id,
                Username = customer.Username
                // Map other properties to response DTO
            };

            return Ok(responseDTO);
        }

        // 8. Retrieve all customers who have rented a particular movie by id
        [HttpGet("movies/{movieId}/customers")]
        public IActionResult GetCustomersForMovie(int movieId)
        {
            var customers = _context.Customers
                .Where(c => c.Rentals.Any(r => r.MovieId == movieId))
                .ToList();

            if (!customers.Any())
            {
                return NotFound("No customers found for the given movie id");
            }

            var responseDTOs = customers.Select(customer => new CustomersForMovieResponseDTO
            {
                Id = customer.Id,
                Username = customer.Username
                // Map other properties to response DTO
            }).ToList();

            return Ok(responseDTOs);
        }

        // 9. Retrieve all movies rented by a customer using customer id
        [HttpGet("{customerId}/movies")]
        public IActionResult GetMoviesForCustomer(int customerId)
        {
            var rentals = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .Select(r => r.Movie)
                .ToList();

            if (!rentals.Any())
            {
                return NotFound("No movies found for the given customer id");
            }

            var responseDTOs = rentals.Select(movie => new MoviesForCustomerResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
                // Map other properties to response DTO
            }).ToList();

            return Ok(responseDTOs);
        }

        // 10. Retrieve the total cost of the movies rented by a customer using customer id
        [HttpGet("{customerId}/totalcost")]
        public IActionResult GetTotalCostForCustomer(int customerId)
        {
            var totalCost = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .Sum(r => r.Movie.RentalPrice);

            return Ok(totalCost);
        }
    }
}
