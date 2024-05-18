using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            // Extract username from JWT token
            var username = User.Identity.Name;

            // Find user in the list
            var user = UserDataStore.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
    }
}
