using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly EF_DataContext _context;

        public MoviesController(EF_DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie(MovieRequestDTO movieDTO)
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

            return Ok(responseDTO);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = _context.Movies.ToList();
            var responseDTOs = movies.Select(movie => new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            }).ToList();
            return Ok(responseDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };
            return Ok(responseDTO);
        }

        [HttpGet("title/{title}")]
        public IActionResult GetMovieByTitle(string title)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Title == title);
            if (movie == null)
            {
                return NotFound();
            }
            var responseDTO = new MovieResponseDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                RentalPrice = movie.RentalPrice
            };
            return Ok(responseDTO);
        }
    }
}
