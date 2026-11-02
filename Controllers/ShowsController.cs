using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.DTOs.Shows;
using MovieTicketBooking.Interfaces;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowsController(IShowService showService)
        {
            _showService = showService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _showService.GetAllShowsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var show = await _showService.GetShowByIdAsync(id);
            if (show == null) return NotFound();
            return Ok(show);
        }

        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetByMovie(int movieId)
        {
            return Ok(await _showService.GetShowsByMovieIdAsync(movieId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShowDto dto)
        {
            var created = await _showService.CreateShowAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.ShowId }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateShowDto dto)
        {
            var result = await _showService.UpdateShowAsync(id, dto);
            if (!result) return NotFound();
            return Ok(new { message = "Show updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _showService.DeleteShowAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}