using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Data;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            // Check if user already exists
            if (UserDataStore.Users.Any(u => u.Username == user.Username))
            {
                return Conflict("Username already exists");
            }

            // Add user to the list
            UserDataStore.Users.Add(user);

            return Ok("User registered successfully");
        }
    }
}
