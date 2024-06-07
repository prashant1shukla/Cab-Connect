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

        [Authorize]
        [HttpPut("end-ride")]
        public IActionResult EndRide(EndRideRequest endRideDetails)
        {
            var emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            var userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            try
            {
                if (emailClaim == null || userTypeClaim == null)
                {
                    // Handle the case where emailClaim or userTypeClaim is null
                    return BadRequest("User information not found in claims.");
                }

                _endRideService.EndRide(endRideDetails, emailClaim?.ToString());
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

        [Authorize]
        [HttpPut("cancle-ride")]
        public IActionResult CancleRide(EndRideRequest cancleRiderDetails)
        {
            var emailClaim = UserClaimsUtil.GetUserEmailClaim(User);
            var userTypeClaim = UserClaimsUtil.GetUserTypeClaim(User);

            try
            {
                if (emailClaim == null || userTypeClaim == null)
                {
                    // Handle the case where emailClaim or userTypeClaim is null
                    return BadRequest("User information not found in claims.");
                }

                _cancleRideService.CancleRide(cancleRiderDetails, emailClaim?.ToString());
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
