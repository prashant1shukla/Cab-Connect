using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services.IServices;

namespace Assignment_3.Services
{
    public class MovieService : IMovieService
    {
        private readonly EF_DataContext _context;

        public MovieService(EF_DataContext context)
        {
            _context = context;
        }

        public MovieResponseDTO AddMovie(MovieRequestDTO movieDTO)
        {
            var movie = new Movie
            {
                Title = movieDTO.Title,
                RentalPrice = movieDTO.RentalPrice
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();

            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };

            return responseDTO;
        }

        public List<MovieResponseDTO> GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            var responseDTOs = movies.Select(movie => new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            }).ToList();
            return responseDTOs;
        }

        public MovieResponseDTO GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return null;
            }
            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };
            return responseDTO;
        }

        public MovieResponseDTO GetMovieByTitle(string title)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Title == title);
            if (movie == null)
            {
                return null;
            }
            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };
            return responseDTO;
        }
    }
}
