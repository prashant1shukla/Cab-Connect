using Assignment_3.DTO.ResponseDTO;
using Assignment_3.Models;
using Assignment_3.Services.IServices;

namespace Assignment_3.Services
{
    /// <summary>
    /// Service class for managing rental-related operations.
    /// </summary>
    public class RentalService : IRentalService
    {
        private readonly EF_DataContext _context;


        public RentalService(EF_DataContext context)
        {
            _context = context;
        }

        // Renting a movie to a customer based on the customer id and movie id
        public RentalResponseDTO RentMovieToCustomer(int customerId, int movieId)
        {
            // Retrieve customer by ID
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return null; 
            }

            // Retrieve movie by ID
            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return null;
            }

            // Create a new rental record
            var rental = new Rental
            {
                CustomerId = customerId,
                MovieId = movieId,
                RentalDate = DateTime.UtcNow
            };

            // Add the rental to the context and save changes to the database
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            // Create and return a response DTO with the rental details
            var responseDTO = new RentalResponseDTO
            {
                CustomerId = rental.CustomerId,
                MovieId = rental.MovieId,
                RentalDate = rental.RentalDate
            };

            return responseDTO;
        }

        // Renting a movie to a customer based on the customer's username and movie's title
        public RentalResponseDTO RentMovieToCustomerByTitleAndUsername(string movieTitle, string username)
        {
            // Retrieve customer by username
            var customer = _context.Customers.FirstOrDefault(c => c.Username == username);
            if (customer == null)
            {
                return null; 
            }

            // Retrieve movie by title
            var movie = _context.Movies.FirstOrDefault(m => m.Title == movieTitle);
            if (movie == null)
            {
                return null; 
            }

            // Create a new rental record
            var rental = new Rental
            {
                CustomerId = customer.Id,
                MovieId = movie.Id,
                RentalDate = DateTime.UtcNow
            };

            // Add the rental to the context and save changes to the database
            _context.Rentals.Add(rental);
            _context.SaveChanges();

            // Create and return a response DTO with the rental details
            var responseDTO = new RentalResponseDTO
            {
                CustomerId = rental.CustomerId,
                MovieId = rental.MovieId,
                RentalDate = rental.RentalDate
            };

            return responseDTO;
        }
    }
}
