using Assigmnent_2.Models;
using Assigmnent_2.ViewModels;

namespace Assigmnent_2.Services.IServices
{
    public interface IAuthenticationService
    {
        UserModel AuthenticateUser(LoginViewModel login);
    }
}
