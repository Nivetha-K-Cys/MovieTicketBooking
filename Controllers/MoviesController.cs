using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Dtos;
using MovieTicketBooking.Interfaces;

namespace MovieTicketBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // Everyone can view movies
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
                return NotFound(new { message = "Movie not found" });

            return Ok(movie);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] string title)
        {
            var movies = await _movieService.SearchMoviesByTitleAsync(title);
            return Ok(movies);
        }

        // Only Admin can create movies
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
        {
            var created = await _movieService.CreateMovieAsync(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.MovieId },
                created
            );
        }

        // Only Admin can update movies
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMovieRequest request)
        {
            var result = await _movieService.UpdateMovieAsync(id, request);

            if (!result)
                return NotFound(new { message = "Movie not found" });

            return Ok(new { message = "Movie updated successfully!" });
        }

        // Only Admin can delete movies
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if (!result)
                return NotFound(new { message = "Movie not found" });

            return NoContent();
        }
    }
}