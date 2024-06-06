using BookTaxi.CustomExceptions;
using BookTaxi.Models.Response;
using BookTaxi.Services;
using BookTaxi.Services.IServices;
using BookTaxi.Utlis;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTaxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverDetailsService _driverDetailsService;
        private readonly IDriverAvailibiltyService _driverAvailibiltyService;

        public DriverController(IDriverDetailsService driverDetailsService, IDriverAvailibiltyService driverAvailibiltyService)
        {
            _driverDetailsService = driverDetailsService;
            _driverAvailibiltyService = driverAvailibiltyService;
        }

        /// <summary>
        /// Registers a new Driver.
        /// </summary>
        /// <param name="DriverResponseViewModel">The data of the Driver to be added.</param>
        [HttpPost("register")]
        public IActionResult RegisterDriver(DriverRequest driverDetails)
        {
            DriverResponse driverResponse = _driverDetailsService.AddDriver(driverDetails);
            return Ok(driverResponse);
        }

        [HttpPut("toggle-availability")]
        public IActionResult ToggleAvailibility()
        {
            var emailClaim = UserUtils.GetUserEmailClaim(User);
            var userTypeClaim = UserUtils.GetUserTypeClaim(User);
           
            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return BadRequest("User information not found in claims.");
            }

            DriverAvailabiltyResponse driverAvailabiltyResponse = _driverAvailibiltyService.ToggleAvailibility(emailClaim?.ToString());
            return Ok(driverAvailabiltyResponse);   
        }
    }

}
