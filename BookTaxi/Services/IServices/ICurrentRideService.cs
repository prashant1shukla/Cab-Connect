using BookTaxi.Models.Response;

namespace BookTaxi.Services.IServices
{
    public interface ICurrentRideService
    {
        public CurrentRideResponse GetCurrentRide(string email, string userType);
    }
}
