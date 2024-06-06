using BookTaxi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTaxi.Models
{
    public class Ride
    {
        [Key]
        public Guid RideId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public string PickUpLocation { get; set; }

        [Required]
        public string DropLocation { get; set; }

        [Required]
        public string OTP { get; set; }

        [Required]
        public RideStatus RideStatus { get; set; }

        //Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
        //public Rating Rating { get; set; }
    }
}
