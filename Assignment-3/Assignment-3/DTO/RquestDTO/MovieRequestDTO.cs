using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTO.RquestDTO
{
    public class MovieRequestDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Title { get; set; }
        [Required]
        [Range(5, 200)]
        public decimal RentalPrice { get; set; }
    }
}
