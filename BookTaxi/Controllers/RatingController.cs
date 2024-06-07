using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models.Request;
using BookTaxi.Utlis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTaxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Rider rates the Driver.
        /// </summary>
        [Authorize]
        [HttpPost("rider-rating")]
        public IActionResult RiderRating(RatingRequest rating)
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
                _ratingService.AddRating(rating, emailClaim, userTypeClaim);
                return Ok("Driver Rated Successfully by Rider");
            }
            catch (RideNotCompletedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (RideNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Driver rates the Rider. 
        /// </summary>
        [Authorize]
        [HttpPost("driver-rating")]
        public IActionResult DriverRating(RatingRequest rating)
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
                _ratingService.AddRating(rating, emailClaim, userTypeClaim);
                return Ok("Rider Rated Successfully by Driver");
            }
            catch (RideNotCompletedException ex)
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
