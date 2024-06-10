using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;
using Assigmnent_2.Services.IServices;
using Assigmnent_2.Data.IData;

namespace Assigmnent_2.Services
{
    public class UserService : IUserService
    {
        
        public UserService()
        {
        }

        public bool RegisterUser(UserModel user)
        {
            if (UserDataStore.Users.Any(u => u.Username == user.Username))
            {
                return false; // Username already exists
            }

            //If the username already does not exist, make new registration
            UserDataStore.Users.Add(user);
            return true;
        }

        // Function to get the User data, it is used in User Controller
        public UserModel GetUserByUsername(string username)
        {
            return UserDataStore.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
