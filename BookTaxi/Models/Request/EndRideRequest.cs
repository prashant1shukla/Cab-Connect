using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Models.Request
{
    public class EndRideRequest
    {
        [Required]
        public Guid RideId { get; set; }
    }
}
