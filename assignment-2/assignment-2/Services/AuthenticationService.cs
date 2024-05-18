using assignment_2.DTO;
using assignment_2.Services;

namespace assignment_2.Services
{
    public interface IAuthenticationService
    {
        string AuthenticateUser(LoginDTO loginModel);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public string AuthenticateUser(LoginDTO loginModel)
        {
            var user = _userService.GetUserByUsername(loginModel.Username);

            Console.WriteLine(loginModel.Password);
            // Check if the user exists
            if (user != null)
            {
                // Verify the password
                if (user.Password == loginModel.Password)
                {
                    // Password is correct, generate and return a token
                    return _tokenService.GenerateToken(user.Username);
                }
            }
            // Authentication failed
            return null;
        }

    }
}
