using BookTaxi.CustomExceptions;
using BookTaxi.Models;
using BookTaxi.Models.Response;
using BookTaxi.Services;
using BookTaxi.Services.IServices;
using BookTaxi.Utlis;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookTaxi.Controllers
{
    /// <summary>
    /// Controller for signing-up and login of riders.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RiderController : ControllerBase
    {
        private readonly IRiderDetailsService _riderDetailsService;
        private readonly IRequestRideService _requestRideService;
        private readonly ICurrentRideService _currentRideService;
        public RiderController(IRiderDetailsService riderDetailsService, IRequestRideService requestRideService, ICurrentRideService currentRideService)
        {
            _riderDetailsService = riderDetailsService;
            _requestRideService = requestRideService;
            _currentRideService = currentRideService;

        }

        /// <summary>
        /// Registers a new Rider.
        /// </summary>
        /// <param name="RiderResponseViewModel">The data of the Rider to be added.</param>
        [HttpPost("register")]
        public IActionResult RegisterRider(RiderRequest riderDetails)
        {
            RiderResponse riderResponse = _riderDetailsService.AddRider(riderDetails);
            return Ok(riderResponse);
        }

        [Authorize]
        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            var emailClaim = UserUtils.GetUserEmailClaim(User);
            var userTypeClaim = UserUtils.GetUserTypeClaim(User);

            // Check if email claim is present
            if (string.IsNullOrEmpty(emailClaim))
            {
                return NotFound("Email claim not found");
            }
            return Ok(new
            {
                Email = emailClaim,
                UserType = userTypeClaim,
            });
        }

        //Applying authorization on get request to fetch user data if a valid token is put as a bearer token
        [Authorize]
        [HttpPost("request-a-ride")]
        public IActionResult RequestARide(RequestRideRequest rideDetails)
        {
            var emailClaim = UserUtils.GetUserEmailClaim(User);
            var userTypeClaim = UserUtils.GetUserTypeClaim(User);
            try
            {
                if (emailClaim == null || userTypeClaim == null)
                {
                    // Handle the case where emailClaim or userTypeClaim is null
                    return BadRequest("User information not found in claims.");
                }
                RequestRideResponse rideRespose = _requestRideService.RequestRide(rideDetails, emailClaim?.ToString(), userTypeClaim?.ToString());
                return Ok(rideRespose);
            }
            catch (NoDriverFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("get-current-ride")]
        public IActionResult GetCurrentRide()
        {
            var emailClaim = UserUtils.GetUserEmailClaim(User);
            var userTypeClaim = UserUtils.GetUserTypeClaim(User);
            try
            {
                if (emailClaim == null || userTypeClaim == null)
                {
                    // Handle the case where emailClaim or userTypeClaim is null
                    return BadRequest("User information not found in claims.");
                }
                CurrentRideResponse currentRideRespose = _currentRideService.GetCurrentRide(emailClaim?.ToString(), userTypeClaim?.ToString());
                return Ok(currentRideRespose);
            }
            catch (NoOngoingRideException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
