using BookTaxi.Models;
using BookTaxi.Services.IServices;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public RiderController(IRiderDetailsService riderDetailsService)
        {
            _riderDetailsService = riderDetailsService;
        }

        /// <summary>
        /// Registers a new Rider.
        /// </summary>
        /// <param name="RiderResponseViewModel">The data of the Rider to be added.</param>
        [HttpPost("register")]
        public IActionResult RegisterRider(RiderRequestViewModel riderDetails)
        {
            RiderResponseViewModel riderResponse = _riderDetailsService.AddRider(riderDetails);
            return Ok(riderResponse);
        }

        //Applying authorization on get request to fetch user data if a valid token is put as a bearer token
        //[Authorize]
        //[HttpPost("request-a-ride")]
        //public IActionResult RequestARide(RequestRideRequestViewModel rideDetails)
        //{
        //    var email = User.Identity.Name;

        //}

    }
}
