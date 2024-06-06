using BookTaxi.Models;
using BookTaxi.ViewModels.RequestViewModels;
using BookTaxi.ViewModels.ResponseViewModels;
using BookTaxi.Enums;
using BookTaxi.CustomExceptions;
using System.ComponentModel.DataAnnotations;
using System;
using BookTaxi.Services.IServices;

namespace BookTaxi.Services
{
    public class RequestRideService: IRequestRideService
    {
        private readonly EF_DataContext _context;
        public RequestRideService(EF_DataContext context)
        {
            _context = context;
        }
        public RequestRideResponse RequestRide(RequestRideRequest rideDetails, string? email, string? userType)
        {
            //checking driver's availability
            var vehicle = _context.Vehicles.LastOrDefault(v => v.VehicleAvailability == VehicleAvailability.Available);

            if (vehicle == null)
            {
                throw new UserAlreadyExistException();
            }
            var rider = _context.Users.FirstOrDefault(u=>u.Email == email);
            

            if (rider == null)
            {
                throw new UserAlreadyExistException();
            }
            var driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId && u.UserRole == UserRole.Driver);


            var ride = new Ride
            {
                RideId = Guid.NewGuid(),
                UserId = rider.UserId,
                VehicleId = vehicle.VehicleId,
                PickUpLocation = rideDetails.PickupLocation,
                DropLocation = rideDetails.DropLocation,
                OTP = new Random().Next(1000, 9999).ToString(),
                RideStatus = RideStatus.Confirmed
            };
            _context.Rides.Add(ride);
            _context.SaveChanges();

            var requestRideResponse = new RequestRideResponse
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
