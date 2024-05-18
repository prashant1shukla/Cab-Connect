using assignment_2.DTO;
using assignment_2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user")]
        [Authorize]
        public IActionResult GetUser()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var user = _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
