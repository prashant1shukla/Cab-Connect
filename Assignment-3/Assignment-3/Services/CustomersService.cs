using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;

namespace Assignment_3.Services
{
    public class CustomerService
    {
        private readonly EF_DataContext _context;

        public CustomerService(EF_DataContext context)
        {
            _context = context;
        }

        public CustomerResponseDTO AddCustomer(CustomerRequestDTO customerDTO)
        {
            var customer = new Customer
            {
                Username = customerDTO.Username
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var responseDTO = new CustomerResponseDTO
            {
                Id = customer.Id,
                Username = customer.Username
            };

            return responseDTO;
        }

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

        public decimal GetTotalCostForCustomer(int customerId)
        {
            var totalCost = _context.Rentals
                .Where(r => r.CustomerId == customerId)
                .Sum(r => r.Movie.RentalPrice);

            return totalCost;
        }
    }
}
