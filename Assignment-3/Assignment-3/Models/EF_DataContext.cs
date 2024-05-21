using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Models
{
    public class EF_DataContext: DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
