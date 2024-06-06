using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.IServices
{
    public interface IRiderDetailsService
    {
        RiderResponse AddRider(RiderRequest riderDetails);
    }
}
