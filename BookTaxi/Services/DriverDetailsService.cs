using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;

namespace BookTaxi.Services
{
    public class DriverDetailsService: IDriverDetailsService
    {
        private readonly EF_DataContext _context;
        public DriverDetailsService(EF_DataContext context)
        {
            _context = context;
        }
        public DriverResponse AddDriver(DriverRequest driverDeatails)
        {

            // Create a new Driver entity from the ViewModel
            var driver = new User
            {
                UserId = Guid.NewGuid(),
                Name = driverDeatails.Name,
                Email = driverDeatails.Email,
                Password = driverDeatails.Password,
                PhoneNumber = driverDeatails.PhoneNumber,
                UserRole= UserRole.Driver
            };

            Vehicle vehicle = null;
            if (Enum.TryParse<VehicleType>(driverDeatails.VehicleType, out VehicleType vehicleType))
            {
                // Create the Vehicle object with the parsed VehicleType
                 vehicle = new Vehicle
                {
                    VehicleId = Guid.NewGuid(),
                    UserId = driver.UserId,
                    VehicleRTONumber = driverDeatails.VehicleRTONumber,
                    VehicleType = vehicleType, // Assign the parsed enum value
                    VehicleAvailability = VehicleAvailability.Available
                };
            }
            else
            {
                // Handle case where driverDeatails.VehicleType is not a valid enum value
                throw new ArgumentException("Invalid vehicle type provided.");
            }

            if (_context.Users.FirstOrDefault(u => u.Email.ToLower() == driverDeatails.Email.ToLower()) != null)
            {
                throw new UserAlreadyExistException();
            }
            // Add the Driver to the context and save changes to the database
            _context.Users.Add(driver);
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            // Create and return a response ViewModel with the added Driver's details
            var driverResponseViewModel = new DriverResponse
            {
                UserId = driver.UserId,
                Name = driver.Name,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                VehicleType=vehicle.VehicleType.ToString(),
                VehicleRTONumber = vehicle.VehicleRTONumber,
                UserRole= driver.UserRole.ToString()
            };
            return driverResponseViewModel;
;
        }

    }
}
