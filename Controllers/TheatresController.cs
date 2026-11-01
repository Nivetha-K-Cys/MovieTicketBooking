using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.DTOs;
using MovieTicketBooking.Services;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly TheaterService _theaterService;

        public TheatersController(TheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TheaterDto>>> GetTheaters()
        {
            var theaters = await _theaterService.GetAllTheatersAsync();
            return Ok(theaters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TheaterDto>> GetTheater(int id)
        {
            var theater = await _theaterService.GetTheaterByIdAsync(id);
            if (theater == null) return NotFound();
            return Ok(theater);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheater([FromBody] TheaterDto theaterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _theaterService.AddTheaterAsync(theaterDto);
            return Ok(new { message = "Theater created successfully!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTheater(int id, [FromBody] TheaterDto theaterDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _theaterService.UpdateTheaterAsync(id, theaterDto);
            return Ok(new { message = "Theater updated successfully!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheater(int id)
        {
            await _theaterService.DeleteTheaterAsync(id);
            return Ok(new { message = "Theater deleted successfully!" });
        }
    }
}