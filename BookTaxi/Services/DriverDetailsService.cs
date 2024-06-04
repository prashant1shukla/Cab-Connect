using BookTaxi.CustomExceptions;
using BookTaxi.Models;
using BookTaxi.Services.IServices;
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
        public DriverResponseViewModel AddDriver(DriverRequestViewModel driverDeatails)
        {
            // Create a new Driver entity from the ViewModel
            var driver = new Driver
            {
                Name = driverDeatails.Name,
                Email = driverDeatails.Email,
                Password = driverDeatails.Password,
                PhoneNumber = driverDeatails.PhoneNumber,
                Vehicletype = driverDeatails.VehicleType,
                VehicleRTONumber= driverDeatails.VehicleRTONumber,

            };
            if (_context.Drivers.FirstOrDefault(u => u.Email.ToLower() == driverDeatails.Email.ToLower()) != null)
            {
                throw new UserAlreadyExistException();
            }
            // Add the Driver to the context and save changes to the database
            _context.Drivers.Add(driver);
            _context.SaveChanges();

            // Create and return a response ViewModel with the added Driver's details
            var driverResponseViewModel = new DriverResponseViewModel
            {
                Name = driver.Name,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                VehicleType=driver.Vehicletype,
                VehicleRTONumber = driver.VehicleRTONumber,
            };

            return driverResponseViewModel;
;
        }

    }
}
