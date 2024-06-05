using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTaxi.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public Guid RatingId { get; set; }
        [ForeignKey("Ride")]
        [Required]
        public Guid RideId { get; set; }
        public double RiderRating { get; set; }
        public double DriverRating { get; set; }
    }
}
