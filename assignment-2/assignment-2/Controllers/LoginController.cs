using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using assignment_2.Models;
using Microsoft.IdentityModel.Tokens;

namespace assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
{
    private IConfiguration _config;

    public LoginController(IConfiguration configuration)
    {
        _config = configuration;
    }

    [HttpPost]
    public IActionResult Login(UserModel user)
    {
        // In a real scenario, you would validate the user's credentials against the database or any other source
        var loggedInUser = AuthenticateUser(user);
        if (loggedInUser != null)
        {
            var tokenString = GenerateJSONWebToken(loggedInUser);
            return Ok(new { token = tokenString });
        }
        else
        {
            return Unauthorized();
        }
    }

    private UserModel AuthenticateUser(UserModel user)
    {
        // Simulating authentication logic - Replace with actual logic to authenticate against database or any other source
        return _users.Find(u => u.Username == user.Username && u.Password == user.Password);
    }

    private string GenerateJSONWebToken(UserModel userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: new List<Claim>
            {
                new Claim("username", userInfo.Username) // Add any additional claims if needed
            },
            expires: DateTime.Now.AddDays(1), // Token expiry time
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
}
