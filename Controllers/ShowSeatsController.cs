using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.DTOs;
using MovieTicketBooking.Services;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowSeatsController : ControllerBase
    {
        private readonly IShowSeatService _showSeatService;

        public ShowSeatsController(IShowSeatService showSeatService)
        {
            _showSeatService = showSeatService;
        }

        [HttpGet("show/{showId}")]
        public async Task<IActionResult> GetSeatsByShowId(int showId)
        {
            var seats = await _showSeatService.GetSeatsByShowIdAsync(showId);
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seat = await _showSeatService.GetByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShowSeatDto showSeatDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _showSeatService.AddAsync(showSeatDto);
            return Ok(new { message = "Show seat created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShowSeatDto showSeatDto)
        {
            if (id != showSeatDto.ShowSeatId) return BadRequest();
            await _showSeatService.UpdateAsync(showSeatDto);
            return Ok(new { message = "Show seat updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _showSeatService.DeleteAsync(id);
            return Ok(new { message = "Show seat deleted successfully" });
        }
    }
}