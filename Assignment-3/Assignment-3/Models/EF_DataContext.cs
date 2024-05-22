using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Models
{
    /// <summary>
    /// Represents the Entity Framework data context for the application.
    /// </summary>
    public class EF_DataContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EF_DataContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the DbSet for movies, customers and rentals.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
