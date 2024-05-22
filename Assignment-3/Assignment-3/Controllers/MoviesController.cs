using Assignment_3.DTO.ResponseDTO;
using Assignment_3.DTO.RquestDTO;
using Assignment_3.Models;
using Assignment_3.Services;
using Assignment_3.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie(MovieRequestDTO movieDTO)
        {
            var responseDTO = _movieService.AddMovie(movieDTO);
            return Ok(responseDTO);
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var responseDTOs = _movieService.GetAllMovies();
            return Ok(responseDTOs);
        }

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
