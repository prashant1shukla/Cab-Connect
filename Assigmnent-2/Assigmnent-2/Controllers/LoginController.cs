using Microsoft.AspNetCore.Mvc;
using Assigmnent_2.Services;
using Assigmnent_2.CustomException;
using Assigmnent_2.ViewModel;


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

        //A Post request to check and Login the user if the valid credentials are passed
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var user = _authenticationService.AuthenticateUser(login);
            var token = _tokenService.GenerateToken(user);
            return Ok(new { token }); 
        }
    }
}
