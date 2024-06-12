using Assigmnent_2.Models;

namespace Assigmnent_2.Services.IServices
{
    public interface IUserService
    {
        bool RegisterUser(UserModel user);
        UserModel GetUserByUsername(string username);
    }
}
