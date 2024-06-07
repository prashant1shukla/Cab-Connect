using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
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
            var ride1 = _context.Rides.FirstOrDefault(r => r.RideId == endRideDetails.RideId && r.RideStatus == RideStatus.YetToStart);
            if (ride1!=null)
            {
                throw new RideNotStartedException();
            }
            var ride = _context.Rides.FirstOrDefault(r => r.RideId == endRideDetails.RideId && r.RideStatus == RideStatus.InProgress);
            if(ride==null)
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

            if(!(rider.Email==email||driver.Email==email))
            {
                throw new RideNotFoundException();
            }
            ride.RideStatus = RideStatus.Completed;
            vehicle.VehicleAvailability = VehicleAvailability.Available;
            _context.SaveChanges();
        }
    }
}
