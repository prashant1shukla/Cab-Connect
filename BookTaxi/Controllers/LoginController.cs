using BookTaxi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.IServices;
using BookTaxi.ViewModels.ResponseViewModels;
using BookTaxi.CustomExceptions;

namespace BookTaxi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Logins the Driver as well as a Rider
        /// </summary>
        /// <param name="string">The JWT token</param>
        [HttpPost]
        public IActionResult Login(LoginRequest loginDeatils)
        {
            try
            {
                LoginResponse user = _authenticationService.AuthenticateUser(loginDeatils);
                string token = _tokenService.GenerateToken(user);
                return Ok(new { token });
            }
            catch(InvalidPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
