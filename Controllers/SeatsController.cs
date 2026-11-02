using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.DTOs.Seats;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpPost("screen/{screenId}/bulk")]
        public async Task<IActionResult> CreateBulkSeats(int screenId, [FromBody] List<MovieTicketBooking.DTOs.Seats.CreateSeatDto> seatRequests)
        {
            var success = await _seatService.CreateBulkSeatsAsync(screenId, seatRequests);
            if (!success)
            {
                return BadRequest(new { message = "Failed to create seats." });
            }
            return Ok(new { message = "Seats created successfully in bulk!" });
        }

        [HttpGet("screen/{screenId}")]
        public async Task<IActionResult> GetSeatsByScreen(int screenId)
        {
            var seats = await _seatService.GetSeatsByScreenIdAsync(screenId);
            return Ok(seats);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] Seat seat)
        {
            var createdSeat = await _seatService.CreateSeatAsync(seat);
            return Ok(createdSeat);
        }
    }
}