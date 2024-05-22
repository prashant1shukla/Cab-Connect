using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTO.RquestDTO
{
    public class CustomerRequestDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
    }
}
