namespace BookTaxi.Models.Request
{
    public class RatingRequest
    {
        public Guid RideId { get; set; }
        public int Rating { get; set; }
    }
}
