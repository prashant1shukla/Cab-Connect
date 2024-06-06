using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTaxi.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public Guid RatingId { get; set; }
        [Required]
        public Guid RideId { get; set; }
        public double RiderRating { get; set; }
        public double DriverRating {  get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }


    } 
}