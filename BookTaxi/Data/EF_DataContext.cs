using BookTaxi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookTaxi.Data
{
    /// <summary>
    /// Represents the Entity Framework data context for the application.
    /// </summary>
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the DbSet for Users, Vehicles, Rides and Driver
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Rating> Ratings { get; set; }



    }
}
