using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services.IServices;

namespace Assignment_3.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly EF_DataContext _context;

        /// <summary>
        /// Service class for managing customer-related operations.
        /// </summary>
        public CustomerService(EF_DataContext context)
        {
            _context = context;
        }

        // Adding a customer to our database
        public CustomerResponseDTO AddCustomer(CustomerRequestDTO customerDTO)
        {
            // Create a new Customer entity from the DTO
            var customer = new Customer
            {
                Username = customerDTO.Username
            };

            // Add the customer to the context and save changes to the database
            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Create and return a response DTO with the added customer's details
            var responseDTO = new CustomerResponseDTO
            {
                Id = customer.Id,
                Username = customer.Username
            };

            return responseDTO;
        }

        // Retrieve customers who have rented the specified movie
        public List<CustomersForMovieResponseDTO> GetCustomersForMovie(int movieId)
        {
            var customers = _context.Customers
                .Where(c => c.Rentals.Any(r => r.MovieId == movieId))
                .Select(customer => new CustomersForMovieResponseDTO
                {
                    Id = customer.Id,
                    Username = customer.Username
                }).ToList();

            return customers;
        }

        // Retrieve movies rented by the specified customer
        public List<MoviesForCustomerResponseDTO> GetMoviesForCustomer(int customerId)
        {
            var rentals = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .Select(r => r.Movie)
                .Select(movie => new MoviesForCustomerResponseDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    RentalPrice = movie.RentalPrice
                }).ToList();

            return rentals;
        }

        // Calculate the total cost of movies rented by the specified customer
        public decimal GetTotalCostForCustomer(int customerId)
        {
            var totalCost = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .Sum(r => r.Movie.RentalPrice);

            return totalCost;
        }
    }
}
