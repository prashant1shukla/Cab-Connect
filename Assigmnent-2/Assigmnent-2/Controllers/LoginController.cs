using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assigmnent_2.Models;
using Assigmnent_2.Data;
using Assigmnent_2.Services;

namespace Assigmnent_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly TokenService _tokenService;

        public LoginController(AuthenticationService authenticationService, TokenService tokenService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            var user = _authenticationService.AuthenticateUser(login);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
