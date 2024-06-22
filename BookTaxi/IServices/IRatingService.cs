using BookTaxi.Models.Request;
using BookTaxi.Services;

namespace BookTaxi.IServices
{
    public interface IRatingService
    {
        public void AddRating(RatingRequest ratingRequest, string email, string userType);

    }
}
