using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;
using Assigmnent_2.ViewModels;
using Assigmnent_2.CustomException;
using Assigmnent_2.Services.IServices;

namespace Assigmnent_2.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public UserModel AuthenticateUser(LoginViewModel login)
        {
            var user = UserDataStore.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
            {
                throw new InvalidPasswordException("Invalid username or password");
            }
            return user;
        }
    }
}
