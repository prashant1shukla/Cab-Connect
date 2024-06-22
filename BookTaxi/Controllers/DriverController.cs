using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models.Request;
using BookTaxi.Models.Response;
using BookTaxi.Services;
using BookTaxi.Utlis;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ICurrentRideService _currentRideService;
        private readonly IStartRideService _startRideService;

        public DriverController(IDriverDetailsService driverDetailsService, IDriverAvailibiltyService driverAvailibiltyService, ICurrentRideService currentRideService, IStartRideService startRideService)
        {
            _driverDetailsService = driverDetailsService;
            _driverAvailibiltyService = driverAvailibiltyService;
            _currentRideService = currentRideService;
            _startRideService = startRideService;
        }

        /// <summary>
        /// Registers a new Driver.
        /// </summary>
        /// <param name="DriverResponse">The data of the Driver that is added.</param>
        [HttpPost("register")]
        public IActionResult RegisterDriver(DriverRequest driverDetails)
        {
            try
            {
                DriverResponse driverResponse = _driverDetailsService.AddDriver(driverDetails);
                return Ok(driverResponse);
            }
            catch(UserAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            } 
        }

        /// <summary>
        /// Changes the availability of a Driver to unavilable and available if they are not in a Ride.
        /// </summary>
        [HttpPut("toggle-availability")]
        public IActionResult ToggleAvailibility()
        {
            string? emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            string? userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return Unauthorized("User information not found in claims.");
            }

            try
            {
                DriverAvailabiltyResponse driverAvailabiltyResponse = _driverAvailibiltyService.ToggleAvailibility(emailClaim);
                return Ok(driverAvailabiltyResponse);
            }
            catch(DriverInRideExcpetion ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets the data of the Driver's current ride.
        /// </summary>
        /// <param name="DriverCurrentRideResponse">The data of the Driver's current ride like Rider's detail and locations</param>
        [Authorize]
        [HttpGet("get-driver-current-ride")]
        public IActionResult GetDriverCurrentRide()
        {
            string? emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            string? userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return Unauthorized("User information not found in claims.");
            }

            try
            {
                DriverCurrentRideResponse currentRideRespose = _currentRideService.GetDriverCurrentRide(emailClaim, userTypeClaim);
                return Ok(currentRideRespose);
            }
            catch (NoOngoingRideException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Start the ride after macthing the right credentials for the ride.
        /// </summary>
        [Authorize]
        [HttpPost("start-ride")]
        public IActionResult StartRide(StartRideRequest startRideDetails)
        {
            string? emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            string? userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return Unauthorized("User information not found in claims.");
            }
            try
            {
                _startRideService.StartRide(startRideDetails, emailClaim, userTypeClaim);
                return Ok("Ride Started");
            }
            catch (CanNotStartRideException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
