using BookTaxi.CustomExceptions;
using BookTaxi.Models;
using BookTaxi.Services.IServices;
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
        public LoginResponseViewModel AuthenticateUser(LoginRequestViewModel login)
        {
            if (login.UserType == "Rider")
            {
                var user = _context.Riders.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                if (user == null)
                {
                    throw new InvalidPasswordException("Invalid username or password");
                }
                return new LoginResponseViewModel
                {
                    Email= login.Email,
                };
            }
            else
            {
                var user = _context.Drivers.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                if (user == null)
                {
                    throw new InvalidPasswordException("Invalid username or password");
                }
                return new LoginResponseViewModel
                {
                    Email = login.Email,
                };
            }
        }
    }
}
