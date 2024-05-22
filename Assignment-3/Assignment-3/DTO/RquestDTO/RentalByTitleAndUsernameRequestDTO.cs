using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTO.RquestDTO
{
    public class RentalByTitleAndUsernameRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string MovieTitle { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
    }
}
