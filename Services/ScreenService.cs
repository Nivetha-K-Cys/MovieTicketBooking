using MovieTicketBooking.Dtos;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Services
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<IEnumerable<ScreenDto>> GetAllScreensAsync()
        {
            var screens = await _screenRepository.GetAllScreensAsync();
            return screens.Select(s => new ScreenDto
            {
                ScreenId = s.ScreenId,
                ScreenName = s.ScreenName,
                TheaterId = s.TheaterId,
                TheaterName = s.Theater?.Name ?? string.Empty
            });
        }

        public async Task<ScreenDto?> GetScreenByIdAsync(int id)
        {
            var s = await _screenRepository.GetScreenByIdAsync(id);
            if (s == null) return null;

            return new ScreenDto
            {
                ScreenId = s.ScreenId,
                ScreenName = s.ScreenName,
                TheaterId = s.TheaterId,
                TheaterName = s.Theater?.Name ?? string.Empty
            };
        }

        public async Task<ScreenDto> CreateScreenAsync(CreateScreenDto createDto)
        {
            var screen = new Screen
            {
                ScreenName = createDto.ScreenName,
                TheaterId = createDto.TheaterId
            };

            // Call repository here, NOT service
            var createdScreen = await _screenRepository.AddScreenAsync(screen);

            return new ScreenDto
            {
                ScreenId = createdScreen.ScreenId,
                ScreenName = createdScreen.ScreenName,
                TheaterId = createdScreen.TheaterId,
                TheaterName = createdScreen.Theater?.Name ?? string.Empty
            };
        }
    }
}