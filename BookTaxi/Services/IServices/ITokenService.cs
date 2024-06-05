using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(LoginResponse user);
    }
}
