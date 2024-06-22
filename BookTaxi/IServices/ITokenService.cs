using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.IServices
{
    public interface ITokenService
    {
        string GenerateToken(LoginResponse user);
    }
}
