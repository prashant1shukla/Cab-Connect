using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookTaxi.Models
{
    /// <summary>
    /// Represents the Entity Framework data context for the application.
    /// </summary>
    public class EF_DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EF_DataContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the DbSet for Rider
        /// </summary>
        public DbSet<Rider> Riders { get; set; }
        
    }
}
