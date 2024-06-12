using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;

namespace Assignment_3.Services.IServices
{
    public interface ICustomerService
    {
        CustomerResponseDTO AddCustomer(CustomerRequestDTO customerDTO);
        List<CustomersForMovieResponseDTO> GetCustomersForMovie(int movieId);
        List<MoviesForCustomerResponseDTO> GetMoviesForCustomer(int customerId);
        decimal GetTotalCostForCustomer(int customerId);
    }
}
