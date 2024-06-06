using BookTaxi.Models;
using BookTaxi.Services.IServices;
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
        public RiderController(IRiderDetailsService riderDetailsService, IRequestRideService requestRideService)
        {
            _riderDetailsService = riderDetailsService;
            _requestRideService = requestRideService;
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
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var userTypeClaim = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

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
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var userTypeClaim = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            var email = emailClaim != null ? emailClaim.ToString() : null;
            var userType = userTypeClaim != null ? userTypeClaim.ToString() : null;

            RequestRideResponse rideRespose = _requestRideService.RequestRide(rideDetails, emailClaim?.ToString(), userTypeClaim?.ToString());
            return Ok(rideRespose);
        }

    }
}
