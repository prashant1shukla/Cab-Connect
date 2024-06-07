using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models.Request;

namespace BookTaxi.Services
{
    public class CancleRideService: ICancleRideService
    {
        private readonly EF_DataContext _context;
        public CancleRideService(EF_DataContext context)
        {
            _context = context;
        }

        public void CancleRide(EndRideRequest cancleRideDetails, string email)
        {
            var rideInProgess = _context.Rides.FirstOrDefault(r => r.RideId == cancleRideDetails.RideId && r.RideStatus == RideStatus.InProgress);
            if (rideInProgess != null)
            {
                throw new RideAlreadyStartedException();
            }
            var ride = _context.Rides.FirstOrDefault(r => r.RideId == cancleRideDetails.RideId && r.RideStatus == RideStatus.YetToStart);
            if (ride == null)
            {
                throw new RideNotFoundException();
            }
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == ride.VehicleId);
            if (vehicle == null)
            {
                throw new RideNotFoundException();
            }
            var rider = _context.Users.FirstOrDefault(u => u.UserId == ride.UserId);
            var driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId);
            if (!(rider.Email == email || driver.Email == email))
            {
                throw new RideNotFoundException();
            }
            ride.RideStatus = RideStatus.Cancelled;
            vehicle.VehicleAvailability = VehicleAvailability.Available;
            _context.SaveChanges();
        }
    }
}
