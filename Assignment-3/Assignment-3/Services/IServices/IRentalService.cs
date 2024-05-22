using Assignment_3.DTO.ResponseDTO;

namespace Assignment_3.Services.IServices
{
    public interface IRentalService
    {
        RentalResponseDTO RentMovieToCustomer(int customerId, int movieId);
        RentalResponseDTO RentMovieToCustomerByTitleAndUsername(string movieTitle, string username);
    }
}
