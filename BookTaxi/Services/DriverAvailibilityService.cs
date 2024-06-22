using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.Models.Response;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services
{
    public class DriverAvailibilityService: IDriverAvailibiltyService
    {
        private readonly EF_DataContext _context;
        public DriverAvailibilityService(EF_DataContext context)
        {
            _context = context;

        }
        public void UpdateVehcileToInRide(Guid vehicleId)
        {
            Vehicle? vehicle = _context.Vehicles.FirstOrDefault(v=>v.VehicleId == vehicleId);
            if (vehicle == null)
            {
                throw new NoDriverFoundException();
            }
            vehicle.VehicleAvailability=VehicleAvailability.RideInProgress;
        }
        public DriverAvailabiltyResponse ToggleAvailibility(string email)
        {
            Vehicle? vehicle = _context.Vehicles.FirstOrDefault(v => v.User.Email == email);
            if (vehicle == null)
            {
                throw new NoOngoingRideException();
            }
            if (vehicle.VehicleAvailability == VehicleAvailability.RideInProgress)
            {
                throw new DriverInRideExcpetion();
            }
            else if (vehicle.VehicleAvailability == VehicleAvailability.Available)
            {
                vehicle.VehicleAvailability = VehicleAvailability.Unavailable;
            }
            else
            {
                vehicle.VehicleAvailability = VehicleAvailability.Available;
            }
            _context.SaveChanges();

            DriverAvailabiltyResponse driverAvailibilityResponse = new DriverAvailabiltyResponse
            {
                VehicleAvailabilty=vehicle.VehicleAvailability.ToString()
            };

            return driverAvailibilityResponse;
        }

    }
}
