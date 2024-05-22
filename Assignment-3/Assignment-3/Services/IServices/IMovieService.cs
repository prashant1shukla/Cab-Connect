using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;

namespace Assignment_3.Services.IServices
{
    public interface IMovieService
    {
        MovieResponseDTO AddMovie(MovieRequestDTO movieDTO);
        List<MovieResponseDTO> GetAllMovies();
        MovieResponseDTO GetMovieById(int id);
        MovieResponseDTO GetMovieByTitle(string title);
    }
}
