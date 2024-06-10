using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Services;
using Assigmnent_2.Services.IServices;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
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

            //successfully returning if the registration is completed
            return Ok("User registered successfully");
        }
    }
}
