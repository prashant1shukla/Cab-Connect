using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Models;
using Assigmnent_2.Services;
using Assigmnent_2.CustomException;

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
            try
            {
                var user = _authenticationService.AuthenticateUser(login);

                if (user == null)
                {
                    throw new InvalidPasswordException("Invalid username or password"); // Throw custom exception
                }

                var token = _tokenService.GenerateToken(user);

                return Ok(new { token });
            }
            catch (InvalidPasswordException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
