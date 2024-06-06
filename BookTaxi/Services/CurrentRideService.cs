using BookTaxi.Models;
using BookTaxi.Models.Response;
using BookTaxi.Services.IServices;
using BookTaxi.CustomExceptions;
using BookTaxi.Enums;


namespace BookTaxi.Services
{
    public class CurrentRideService: ICurrentRideService
    {
        private readonly EF_DataContext _context;
        public CurrentRideService(EF_DataContext context)
        {
            _context = context;
        }

        public CurrentRideResponse GetCurrentRide(string email, string userType)
        {
            // Convert userType string to UserRole enum
            if (!Enum.TryParse<UserRole>(userType, out UserRole userRole))
            {
                // Handle invalid userType
                throw new ArgumentException("Invalid user type.", nameof(userType));
            }


            var ride = _context.Rides.FirstOrDefault(r => r.User.Email == email && r.User.UserRole == userRole);
            var vehicle = _context.Vehicles.FirstOrDefault(v=>v.VehicleId==ride.VehicleId);
            var driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId);


            if (ride == null)
            {
                throw new NoOngoingRideException();
            }
            else if(ride.RideStatus==RideStatus.Confirmed)
            {
                return new CurrentRideResponse
                {
                    DriverName = driver.Name,
                    PhoneNumber = driver.PhoneNumber,
                    VehicleType = vehicle.VehicleType.ToString(),
                    VehicleRTONumber = vehicle.VehicleRTONumber.ToString(),
                    OTP = ride.OTP,
                    rideStatus = ride.RideStatus.ToString()
                };
            }
            else
            {
                return new CurrentRideResponse
                {
                    DriverName = driver.Name,
                    PhoneNumber = driver.PhoneNumber,
                    VehicleType = vehicle.VehicleType.ToString(),
                    VehicleRTONumber = vehicle.VehicleRTONumber.ToString(),
                    rideStatus = ride.RideStatus.ToString()
                };
            }

        }
    }
}
