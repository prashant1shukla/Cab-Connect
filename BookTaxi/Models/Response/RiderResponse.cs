using BookTaxi.Enums;

namespace BookTaxi.ViewModels.ResponseViewModels
{
    public class RiderResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; }
    }
}
