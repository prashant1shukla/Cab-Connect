using BookTaxi.Services.IServices;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTaxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverDetailsService _driverDetailsService;
        public DriverController(IDriverDetailsService driverDetailsService)
        {
            _driverDetailsService = driverDetailsService;
        }

        /// <summary>
        /// Registers a new Driver.
        /// </summary>
        /// <param name="DriverResponseViewModel">The data of the Driver to be added.</param>
        [HttpPost("register")]
        public IActionResult RegisterDriver(DriverRequestViewModel driverDetails)
        {
            DriverResponseViewModel driverResponse = _driverDetailsService.AddDriver(driverDetails);
            return Ok(driverResponse);
        }
    }
}
