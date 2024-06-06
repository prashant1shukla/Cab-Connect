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

        public RideController(IEndRideService endRideService)
        {
            _endRideService = endRideService;
        }

        [Authorize]
        [HttpPut("end-ride")]
        public IActionResult EndRide(EndRideRequest endRideDetails)
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
    }
}
