using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Models.Request
{
    public class RatingRequest
    {
        [Required]
        public Guid RideId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating value must be between 1 and 5.")]
        public int Rating { get; set; }
    }
}
