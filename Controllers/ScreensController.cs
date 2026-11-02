using Microsoft.AspNetCore.Mvc;
using MovieTicketBooking.Dtos;
using MovieTicketBooking.Interfaces;

namespace MovieTicketBooking.Controllers
{
    [Route("api/screens")]
    [ApiController]
    public class ScreensController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreensController(IScreenService screenService)
        {
            _screenService = screenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllScreens()
        {
            var screens = await _screenService.GetAllScreensAsync();
            return Ok(screens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreenById(int id)
        {
            var screen = await _screenService.GetScreenByIdAsync(id);
            if (screen == null)
            {
                return NotFound(new { message = "Screen not found" });
            }
            return Ok(screen);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScreen([FromBody] CreateScreenDto createDto)
        {
            var createdScreen = await _screenService.CreateScreenAsync(createDto);
            return CreatedAtAction(nameof(GetScreenById), new { id = createdScreen.ScreenId }, createdScreen);
        }
    }
}