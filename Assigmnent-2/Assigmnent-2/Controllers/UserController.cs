using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;
using Assigmnent_2.Services;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //Applying authorisation on get request to fetch user data if valid token is put as a bearer token
        [Authorize]
        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            var username = User.Identity.Name;
            // Compaing the usernames using GetUserByUsername function
            var user = _userService.GetUserByUsername(username);

            //For invalid token
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Returning the user data if valid token is passed
            return Ok(user);
        }
    }
}
