using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;

namespace Assigmnent_2.Services
{
    public class UserService
    {
        public bool RegisterUser(UserModel user)
        {
            // Username already exists
            if (UserDataStore.Users.Any(u => u.Username == user.Username))
            {
                return false; 
            }

            //If the username already doest not exsist make new registration
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
