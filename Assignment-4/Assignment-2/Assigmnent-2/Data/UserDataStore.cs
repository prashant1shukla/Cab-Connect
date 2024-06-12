using Assigmnent_2.Models;

namespace Assigmnent_2.Data
{
    public static class UserDataStore
    {
        // instead of using a database, made use of a list that will take care of user information which is required at every step
        public static List<UserModel> Users { get; } = new List<UserModel>();
    }
}
