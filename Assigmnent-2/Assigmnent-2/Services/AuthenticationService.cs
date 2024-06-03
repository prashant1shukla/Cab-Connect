using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;
using System.Security.Authentication;
using Assigmnent_2.CustomException;
using Assigmnent_2.ViewModel;

namespace Assigmnent_2.Services
{
    public class AuthenticationService
    {
        //Used at the time of Login, where we are checking is the user is already registerd or not on the basis of Username and Password in our list.
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
