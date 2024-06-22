using BookTaxi.Models.Request;

namespace BookTaxi.IServices
{
    public interface IStartRideService
    {
        public void StartRide(StartRideRequest startRideDetails, string email, string userType);
    }
}
