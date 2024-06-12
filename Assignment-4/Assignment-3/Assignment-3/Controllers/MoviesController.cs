using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    /// <summary>
    /// Controller for managing movies and their associated operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Adds a new movie.
        /// </summary>
        /// <param name="movieDTO">The data of the movie to be added.</param>
        [HttpPost]
        public IActionResult AddMovie(MovieRequestDTO movieDTO)
        {
            if (string.IsNullOrEmpty(movieDTO.Title))
            {
                return BadRequest();
            }
            var responseDTO = _movieService.AddMovie(movieDTO);
            return Ok(responseDTO);
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var responseDTOs = _movieService.GetAllMovies();
            return Ok(responseDTOs);
        }

        /// <summary>
        /// Retrieves a movie by its ID.
        /// </summary>
        /// <param name="id">The ID of the movie.</param>
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var responseDTO = _movieService.GetMovieById(id);
            if (responseDTO == null)
            {
                return NotFound();
            }
            return Ok(responseDTO);
        }

        /// <summary>
        /// Retrieves a movie by its title.
        /// </summary>
        /// <param name="title">The title of the movie.</param>
        [HttpGet("title/{title}")]
        public IActionResult GetMovieByTitle(string title)
        {
            var responseDTO = _movieService.GetMovieByTitle(title);
            if (responseDTO == null)
            {
                return NotFound();
            }
            return Ok(responseDTO);
        }
    }
}
