using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models.Request;
using BookTaxi.Models.Response;
using BookTaxi.Utlis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTaxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IEndRideService _endRideService;
        private readonly ICancleRideService _cancleRideService;
        
        public RideController(IEndRideService endRideService, ICancleRideService cancleRideService)
        {
            _endRideService = endRideService;
            _cancleRideService = cancleRideService;
        }

        /// <summary>
        /// End the Ride.
        /// </summary>
        [Authorize]
        [HttpPut("end-ride")]
        public IActionResult EndRide(EndRideRequest endRideDetails)
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
                _endRideService.EndRide(endRideDetails, emailClaim);
                return Ok("Ride Ended Sucessfully");
            }
            catch (RideNotStartedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RideNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Cancels a the Ride.
        /// </summary>
        [Authorize]
        [HttpPut("cancle-ride")]
        public IActionResult CancleRide(EndRideRequest cancleRiderDetails)
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
                _cancleRideService.CancleRide(cancleRiderDetails, emailClaim);
                return Ok("Ride Cancelled Sucessfully");
            }
            catch (RideAlreadyStartedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RideNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
