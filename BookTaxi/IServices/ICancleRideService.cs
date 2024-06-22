using BookTaxi.Models.Request;

namespace BookTaxi.IServices
{
    public interface ICancleRideService
    {
        public void CancleRide(EndRideRequest cancleRideDetails, string email);
    }
}
