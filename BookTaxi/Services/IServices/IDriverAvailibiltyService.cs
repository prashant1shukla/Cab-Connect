using BookTaxi.Models.Response;

namespace BookTaxi.Services.IServices
{
    public interface IDriverAvailibiltyService
    {
        public void UpdateVehcileToInRide(Guid vehicleId);
        public DriverAvailabiltyResponse ToggleAvailibility(string email);
    }
}
