using BookTaxi.Services.IServices;
using BookTaxi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookTaxi.ViewModels.RequestViewModels;

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

        [HttpPost]
        public IActionResult Login(LoginRequestViewModel loginDeatils)
        {
            var user = _authenticationService.AuthenticateUser(loginDeatils);
            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
