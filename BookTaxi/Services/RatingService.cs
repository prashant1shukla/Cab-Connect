using BookTaxi.CustomExceptions;
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
            var ride=_context.Rides.FirstOrDefault(r=>r.RideId == ratingRequest.RideId);
            if (ride.RideStatus != RideStatus.Completed)
            {
                throw new RideNotCompletedException();
            }
            if (ride == null)
            {
                throw new RideNotFoundException();
            }

            // Convert userType string to UserRole enum
            if (!Enum.TryParse<UserRole>(userType, out UserRole userRole))
            {
                // Handle invalid userType
                throw new ArgumentException("Invalid user type.", nameof(userType));
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
