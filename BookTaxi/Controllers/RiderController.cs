using BookTaxi.Models;
using BookTaxi.Services.IServices;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
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
        [HttpPost]
        public IActionResult RegisterRider(RiderRequestViewModel riderDetails)
        {
            RiderResponseViewModel riderResponse = _riderDetailsService.AddRider(riderDetails);
            //Checking if the username is already there or not
            //if (!riderResponse)
            //{
            //    return Conflict("Email already exists");
            //}

            //successfully returning if the registration is completed
            return Ok(riderResponse);
        }
    }
}
