using System.ComponentModel.DataAnnotations;

namespace assignment_2.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }


}
