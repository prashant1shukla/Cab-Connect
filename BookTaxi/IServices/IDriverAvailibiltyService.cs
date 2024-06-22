using BookTaxi.Models.Response;

namespace BookTaxi.IServices
{
    public interface IDriverAvailibiltyService
    {
        public void UpdateVehcileToInRide(Guid vehicleId);
        public DriverAvailabiltyResponse ToggleAvailibility(string email);
    }
}
