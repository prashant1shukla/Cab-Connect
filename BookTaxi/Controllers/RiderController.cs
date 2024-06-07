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
        /// <param name="RiderResponse">The data of the Rider that is added.</param>
        [HttpPost("register")]
        public IActionResult RegisterRider(RiderRequest riderDetails)
        {
            try
            {
                RiderResponse riderResponse = _riderDetailsService.AddRider(riderDetails);
                return Ok(riderResponse);
            }
            catch(UserAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Requests for a ride
        /// </summary>
        /// <param name="RiderResponse">The data of the Ride that is confirmed.</param>
        //Applying authorization on get request to fetch user data if a valid token is put as a bearer token
        [Authorize]
        [HttpPost("request-a-ride")]
        public IActionResult RequestARide(RequestRideRequest rideDetails)
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
                RequestRideResponse rideRespose = _requestRideService.RequestRide(rideDetails, emailClaim, userTypeClaim);
                return Ok(rideRespose);
            }
            catch (NoDriverFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Gets the data of the Rider's current ride.
        /// </summary>
        /// <param name="CurrentRideResponse">The data of the Rider's current ride like Driver's detail and OTP</param>
        [Authorize]
        [HttpGet("get-rider-current-ride")]
        public IActionResult GetCurrentRide()
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
                CurrentRideResponse currentRideRespose = _currentRideService.GetCurrentRide(emailClaim, userTypeClaim);
                return Ok(currentRideRespose);
            }
            catch (NoOngoingRideException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
