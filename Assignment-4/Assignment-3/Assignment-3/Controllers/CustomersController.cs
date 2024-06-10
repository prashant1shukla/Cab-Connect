using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    /// <summary>
    /// Controller for managing customers and their associated operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customerDTO">The data of the customer to be added.</param>
        [HttpPost]
        public IActionResult AddCustomer(CustomerRequestDTO customerDTO)
        {
            if (string.IsNullOrEmpty(customerDTO.Username))
            {
                return BadRequest("Username cannot be null or empty.");
            }
            var responseDTO = _customerService.AddCustomer(customerDTO);
            return Ok(responseDTO);
        }

        /// <summary>
        /// Retrieves customers who have rented a specific movie.
        /// </summary>
        /// <param name="movieId">The ID of the movie.</param>
        [HttpGet("movies/{movieId}/customers")]
        public IActionResult GetCustomersForMovie(int movieId)
        {
            var responseDTOs = _customerService.GetCustomersForMovie(movieId);
            if (!responseDTOs.Any())
            {
                return NotFound("No customers found for the given movie id");
            }
            return Ok(responseDTOs);
        }

        /// <summary>
        /// Retrieves movies rented by a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        [HttpGet("{customerId}/movies")]
        public IActionResult GetMoviesForCustomer(int customerId)
        {
            var responseDTOs = _customerService.GetMoviesForCustomer(customerId);
            if (!responseDTOs.Any())
            {
                return NotFound("No movies found for the given customer id");
            }
            return Ok(responseDTOs);
        }

        /// <summary>
        /// Calculates the total cost of movies rented by a specific customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        [HttpGet("{customerId}/totalcost")]
        public IActionResult GetTotalCostForCustomer(int customerId)
        {
            var totalCost = _customerService.GetTotalCostForCustomer(customerId);
            return Ok(totalCost);
        }
    }
}
