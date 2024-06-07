using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.Models.Response;
using BookTaxi.Services;
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

        //Applying authorization on get request to fetch user data if a valid token is put as a bearer token
        [Authorize]
        [HttpPost("request-a-ride")]
        public IActionResult RequestARide(RequestRideRequest rideDetails)
        {
            var emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            var userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return BadRequest("User information not found in claims.");
            }

            try
            {
                RequestRideResponse rideRespose = _requestRideService.RequestRide(rideDetails, emailClaim.ToString(), userTypeClaim.ToString());
                return Ok(rideRespose);
            }
            catch (NoDriverFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("get-rider-current-ride")]
        public IActionResult GetCurrentRide()
        {
            var emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            var userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            if (emailClaim == null || userTypeClaim == null)
            {
                // Handle the case where emailClaim or userTypeClaim is null
                return BadRequest("User information not found in claims.");
            }

            try
            {
                
                CurrentRideResponse currentRideRespose = _currentRideService.GetCurrentRide(emailClaim.ToString(), userTypeClaim.ToString());
                return Ok(currentRideRespose);
            }
            catch (NoOngoingRideException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
