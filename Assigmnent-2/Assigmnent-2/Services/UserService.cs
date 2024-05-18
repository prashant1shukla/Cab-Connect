using Assigmnent_2.Models;
using Assigmnent_2.Data;
using System.Linq;

namespace Assigmnent_2.Services
{
    public class UserService
    {
        public bool RegisterUser(UserModel user)
        {
            if (UserDataStore.Users.Any(u => u.Username == user.Username))
            {
                return false; // Username already exists
            }

            UserDataStore.Users.Add(user);
            return true;
        }

        public UserModel GetUserByUsername(string username)
        {
            return UserDataStore.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
