using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequestDTO customerDTO)
        {
            var responseDTO = _customerService.AddCustomer(customerDTO);
            return Ok(responseDTO);
        }

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

        [HttpGet("{customerId}/totalcost")]
        public IActionResult GetTotalCostForCustomer(int customerId)
        {
            var totalCost = _customerService.GetTotalCostForCustomer(customerId);
            return Ok(totalCost);
        }
    }
}
