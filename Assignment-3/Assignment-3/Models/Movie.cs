namespace Assignment_3.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal RentalPrice { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
