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

        [Authorize]
        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            var username = User.Identity.Name;
            var user = _userService.GetUserByUsername(username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
    }
}
