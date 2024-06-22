using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.Models.Request;

namespace BookTaxi.Services
{
    public class EndRideService: IEndRideService
    {
        private readonly EF_DataContext _context;
        public EndRideService(EF_DataContext context)
        {
            _context = context;
        }

        public void EndRide(EndRideRequest endRideDetails, string email)
        {
            Ride? rideYetToStart = _context.Rides.FirstOrDefault(r => r.RideId == endRideDetails.RideId && r.RideStatus == RideStatus.YetToStart);
            if (rideYetToStart != null)
            {
                throw new RideNotStartedException();
            }
            Ride? ride = _context.Rides.FirstOrDefault(r => r.RideId == endRideDetails.RideId && r.RideStatus == RideStatus.InProgress);
            if(ride==null)
            {
                throw new RideNotFoundException();
            }
            Vehicle? vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == ride.VehicleId);
            if (vehicle == null)
            {
                throw new RideNotFoundException();
            }
            User? rider = _context.Users.FirstOrDefault(u => u.UserId == ride.UserId);
            if (rider == null)
            {
                throw new RideNotFoundException();
            }
            User? driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId);
            if (driver == null)
            {
                throw new RideNotFoundException();
            }
            if (!(rider.Email==email||driver.Email==email))
            {
                throw new RideNotFoundException();
            }
            ride.RideStatus = RideStatus.Completed;
            vehicle.VehicleAvailability = VehicleAvailability.Available;
            _context.SaveChanges();
        }
    }
}
