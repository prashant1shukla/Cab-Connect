using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;

namespace Assigmnent_2.Services
{
    public class AuthenticationService
    {
        public UserModel AuthenticateUser(LoginModel login)
        {
            return UserDataStore.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
        }
    }
}
