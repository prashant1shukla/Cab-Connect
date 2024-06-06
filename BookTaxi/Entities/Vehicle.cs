using BookTaxi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTaxi.Models
{
    public class Vehicle
    {
        [Key]
        [Required]  
        public Guid VehicleId { get; set; }

        [Required]
        public Guid UserId { get; set; } 

        [Required]
        public string VehicleRTONumber { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; } 

        [Required]
        public VehicleAvailability VehicleAvailability { get; set; }

        //Navigation property
        [ForeignKey("UserId")]

        public User User { get; set; }
    }
}
