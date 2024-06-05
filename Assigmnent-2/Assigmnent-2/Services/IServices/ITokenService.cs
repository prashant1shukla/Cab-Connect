using Assigmnent_2.Models;

namespace Assigmnent_2.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(UserModel user);
    }
}
