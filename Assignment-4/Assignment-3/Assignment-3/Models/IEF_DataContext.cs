using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Models
{
    public interface IEF_DataContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Rental> Rentals { get; set; }

        int SaveChanges();
    }
}
