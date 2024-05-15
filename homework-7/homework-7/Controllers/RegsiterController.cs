using homework_7.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homework_7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegsiterController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(UserRegistrationDTO userDTO)
        {
            return Ok("User registered successfully!");
        }
    }
}
