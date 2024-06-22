using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using BookTaxi.Enums;
using BookTaxi.CustomExceptions;
using System.ComponentModel.DataAnnotations;
using System;
using BookTaxi.IServices;
using BookTaxi.Utlis;
using BookTaxi.Data;

namespace BookTaxi.Services
{
    public class RequestRideService: IRequestRideService
    {
        private readonly EF_DataContext _context;
        private readonly IDriverAvailibiltyService _driverAvailability;

        public RequestRideService(EF_DataContext context, IDriverAvailibiltyService driverAvailability)
        {
            _context = context;
            _driverAvailability = driverAvailability;
        }
        public RequestRideResponse RequestRide(RequestRideRequest rideDetails, string email, string userType)
        {
            //checking driver's availability
            Vehicle? vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleAvailability == VehicleAvailability.Available && v.VehicleType == (VehicleType)Enum.Parse(typeof(VehicleType), rideDetails.TypeOfRide) && v.User.Email!=email);
            if (vehicle == null)
            {
                throw new NoDriverFoundException();
            }
            User? rider = _context.Users.FirstOrDefault(u=>u.Email == email && u.UserRole == UserRole.Rider);
            if (rider == null)
            {
                throw new NoDriverFoundException();
            }
            User? driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId && u.UserRole == UserRole.Driver);
            if (driver == null)
            {
                throw new NoDriverFoundException();
            }

            _driverAvailability.UpdateVehcileToInRide(vehicle.VehicleId);

            Ride ride = new Ride
            {
                RideId = Guid.NewGuid(),
                UserId = rider.UserId,
                VehicleId = vehicle.VehicleId,
                PickUpLocation = rideDetails.PickupLocation,
                DropLocation = rideDetails.DropLocation,
                OTP = OTPGeneratorUtil.GenerateOTP(),
                RideStatus = RideStatus.YetToStart
            };
            _context.Rides.Add(ride);
            _context.SaveChanges();

            RequestRideResponse requestRideResponse = new RequestRideResponse
            {
                RideId = ride.RideId,
                DriverName = driver.Name,
                DriverNumberPlate = vehicle.VehicleRTONumber,
                DriverVehicleType = vehicle.VehicleType.ToString(),
                OTP = ride.OTP,
                RideStatus = ride.RideStatus.ToString()
            };

            return requestRideResponse;
        }
    }
}
