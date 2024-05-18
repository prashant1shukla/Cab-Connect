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

        //Post request to register a user
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            //Checking if the username is already there or not
            if (!_userService.RegisterUser(user))
            {
                return Conflict("Username already exists");
            }

            //successfully returning if the regsitration is completed
            return Ok("User registered successfully");
        }
    }
}
