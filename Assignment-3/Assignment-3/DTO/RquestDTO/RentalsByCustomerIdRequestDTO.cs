using System.ComponentModel.DataAnnotations;

namespace Assignment_3.DTO.RquestDTO
{
    public class RentalsByCustomerIdRequestDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid customer ID")]
        public int CustomerId { get; set; }
    }
}
