using BookTaxi.CustomExceptions;
using BookTaxi.Data;
using BookTaxi.Enums;
using BookTaxi.IServices;
using BookTaxi.Models;
using BookTaxi.Models.Request;
using System.Xml.Serialization;

namespace BookTaxi.Services
{
    public class RatingService: IRatingService
    {
        private readonly EF_DataContext _context;
        public RatingService(EF_DataContext context)
        {
            _context = context;
        }
        public void AddRating(RatingRequest ratingRequest, string email, string userType)
        {
            // Convert userType string to UserRole enum
            if (!Enum.TryParse<UserRole>(userType, out UserRole userRole))
            {
                // Handle invalid userType
                throw new ArgumentException("Invalid user type.", nameof(userType));
            }

            var ride=_context.Rides.FirstOrDefault(r=>r.RideId == ratingRequest.RideId);
            if (ride == null)
            {
                throw new RideNotFoundException();
            }
            if (ride.RideStatus != RideStatus.Completed)
            {
                throw new RideNotCompletedException();
            }
            if(userRole==UserRole.Rider)
            {
                var rider= _context.Users.FirstOrDefault(u=>u.Email== email);
                if (rider == null)
                {
                    throw new RideNotFoundException();
                }
                if(ride.UserId!=rider.UserId)
                {
                    throw new RideNotFoundException();
                }
            }
            else
            {
                var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == ride.VehicleId);
                if (vehicle == null)
                {
                    throw new RideNotFoundException();
                }
                var driver = _context.Users.FirstOrDefault(u => u.UserId == vehicle.UserId);
                if (driver.Email != email)
                {
                    throw new RideNotFoundException();
                }
            }

            var ratings = new Rating
            {
                RatingId = Guid.NewGuid(),
                RideId = ratingRequest.RideId,
                RatedBy= userRole,
                Ratings=ratingRequest.Rating
            };
            _context.Ratings.Add(ratings);
            _context.SaveChanges();
        }
    }
}
