using BookTaxi.Models.Request;

namespace BookTaxi.IServices
{
    public interface IEndRideService
    {
        public void EndRide(EndRideRequest endRideRequest, string email);
    }
}
