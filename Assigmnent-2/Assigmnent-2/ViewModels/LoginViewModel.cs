using System.ComponentModel.DataAnnotations;

namespace Assigmnent_2.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
