using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models.Request;
using BookTaxi.Utlis;
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
        [HttpPost("rider-rating")]
        public IActionResult RiderRating(RatingRequest rating)
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

                _ratingService.AddRating(rating, emailClaim?.ToString(), userTypeClaim?.ToString());
                return Ok("Driver Rated Sucessfully by Rider");
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
        [HttpPost("driver-rating")]
        public IActionResult DriverRating(RatingRequest rating)
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

                _ratingService.AddRating(rating, emailClaim?.ToString(), userTypeClaim?.ToString());
                return Ok("Driver Rated Sucessfully by Rider");
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
