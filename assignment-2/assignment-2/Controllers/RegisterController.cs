using assignment_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
{
    private static readonly List<UserModel> _users = new List<UserModel>();

    [HttpPost]
    public IActionResult Register(UserModel model)
    {
        // Add the user to the list (in real scenario, this data would be persisted)
        _users.Add(model);

        return Ok(new { message = "User registered successfully" });
    }
}
}
