using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Services;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserService _userService;

        public RegisterController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (!_userService.RegisterUser(user))
            {
                return Conflict("Username already exists");
            }

            return Ok("User registered successfully");
        }
    }
}
