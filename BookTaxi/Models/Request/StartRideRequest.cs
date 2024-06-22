using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Models.Request
{
    public class StartRideRequest
    {
        [Required]
        public Guid RideId { get; set; }

        [Required]
        [Range(1000, 9999, ErrorMessage = "Rating value must be between 1000 and 9999.")]
        public string OTP { get; set; }
    }
}
