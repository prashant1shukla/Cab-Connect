using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services.IServices
{
    public interface IAuthenticationService
    {
        LoginResponseViewModel AuthenticateUser(LoginRequestViewModel loginRequestViewModel);
    }
}
