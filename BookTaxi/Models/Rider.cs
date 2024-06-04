using BookTaxi.Validations;
using System.ComponentModel.DataAnnotations;

namespace BookTaxi.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
