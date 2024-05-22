using Assignment_3.DTO.ResponseDTO;
using Assignment_3.Models;
using Assignment_3.Services.IServices;

namespace Assignment_3.Services
{
    public class RentalService : IRentalService
    {
        private readonly EF_DataContext _context;

        public RentalService(EF_DataContext context)
        {
            _context = context;
        }

        public RentalResponseDTO RentMovieToCustomer(int customerId, int movieId)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == customerId);
            if (customer == null)
            {
                return null; // or handle error
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return null; // or handle error
            }

            var rental = new Rental
            {
                CustomerId = customerId,
                MovieId = movieId,
                RentalDate = DateTime.UtcNow
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();

            var responseDTO = new RentalResponseDTO
            {
                CustomerId = rental.CustomerId,
                MovieId = rental.MovieId,
                RentalDate = rental.RentalDate
            };

            return responseDTO;
        }

        public RentalResponseDTO RentMovieToCustomerByTitleAndUsername(string movieTitle, string username)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Username == username);
            if (customer == null)
            {
                return null; // or handle error
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Title == movieTitle);
            if (movie == null)
            {
                return null; // or handle error
            }

            var rental = new Rental
            {
                CustomerId = customer.Id,
                MovieId = movie.Id,
                RentalDate = DateTime.UtcNow
            };

            _context.Rentals.Add(rental);
            _context.SaveChanges();

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
