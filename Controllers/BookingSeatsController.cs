using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Services.Interfaces;

namespace MovieTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSeatsController : ControllerBase
    {
        private readonly IBookingSeatService _bookingSeatService;

        public BookingSeatsController(IBookingSeatService bookingSeatService)
        {
            _bookingSeatService = bookingSeatService;
        }

        [HttpGet("booking/{bookingId}")]
        public async Task<IActionResult> GetSeatsForBooking(int bookingId)
        {
            var seats = await _bookingSeatService.GetSeatsForBookingAsync(bookingId);
            return Ok(seats);
        }
    }
}