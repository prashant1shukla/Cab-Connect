using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services.IServices
{
    public interface IRequestRideService
    {
        RequestRideResponse RequestRide(RequestRideRequest rideDetails, string? email, string? userType);
        
    }
}
