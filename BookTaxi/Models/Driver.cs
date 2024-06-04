namespace BookTaxi.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Vehicletype { get; set; }
        public string VehicleRTONumber { get; set; }
        public bool DriverAvailability { get; set; } = true;
    }
}
