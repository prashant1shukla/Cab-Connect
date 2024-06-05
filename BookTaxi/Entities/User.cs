using BookTaxi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTaxi.Models
{
    public class User
    {
        //For generating unique and random UserId
        [Key]
        [Required]
        public Guid UserId { get; set; } 

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public string PhoneNumber { get; set; }

        // It have have only 'Rider' or 'Driver' UserRole
        [Required]
        public UserRole UserRole { get; set; }

        //Navigation property
        public Vehicle Vehicle { get; set; }
        public Ride Ride { get; set; }
    }
}
