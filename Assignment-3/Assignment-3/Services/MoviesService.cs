using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services.IServices;

namespace Assignment_3.Services
{
    /// <summary>
    /// Service class for managing movie-related operations.
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly EF_DataContext _context;

        public MovieService(EF_DataContext context)
        {
            _context = context;
        }

        public MovieResponseDTO AddMovie(MovieRequestDTO movieDTO)
        {
            // Create a new Movie entity from the DTO
            var movie = new Movie
            {
                Title = movieDTO.Title,
                RentalPrice = movieDTO.RentalPrice
            };

            // Add the movie to the context and save changes to the database.
            _context.Movies.Add(movie);
            _context.SaveChanges();

            // Create and return a response DTO with the added movie's details
            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };

            return responseDTO;
        }

        // Retirving all the movies in the form of a list
        public List<MovieResponseDTO> GetAllMovies()
        {
            // Retrieve all movies from the database and map them to response DTOs
            var movies = _context.Movies.ToList();
            var responseDTOs = movies.Select(movie => new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            }).ToList();
            return responseDTOs;
        }

        //Retriving movies by matching their id
        public MovieResponseDTO GetMovieById(int id)
        {
            // Retrieve a movie by its ID and map it to a response DTO
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

        //Retriving movies by matching their movie title
        public MovieResponseDTO GetMovieByTitle(string title)
        {
            // Retrieve a movie by its title and map it to a response DTO
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
