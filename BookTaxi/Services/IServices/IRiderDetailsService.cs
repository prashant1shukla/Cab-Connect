using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services.IServices
{
    public interface IRiderDetailsService
    {
        RiderResponse AddRider(RiderRequest riderDetails);
    }
}
