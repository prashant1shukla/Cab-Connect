using BookTaxi.Models.Response;

namespace BookTaxi.IServices
{
    public interface ICurrentRideService
    {
        public CurrentRideResponse GetCurrentRide(string email, string userType);
        public DriverCurrentRideResponse GetDriverCurrentRide(string email, string userType);
    }
}
