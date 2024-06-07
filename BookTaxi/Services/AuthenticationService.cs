using BookTaxi.CustomExceptions;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly EF_DataContext _context;
        public AuthenticationService(EF_DataContext context)
        {
            _context = context;
        }
        public LoginResponse AuthenticateUser(LoginRequest login)
        { 
                var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                if (user == null)
                {
                    throw new InvalidPasswordException("Invalid username or password");
                }
                return new LoginResponse
                {
                    Email= login.Email,
                    UserType = login.UserType
                };
            
        }
    }
}
