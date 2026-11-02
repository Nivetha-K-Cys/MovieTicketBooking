using MovieTicketBooking.Dtos;

namespace MovieTicketBooking.Interfaces
{
    public interface IScreenService
    {
        Task<IEnumerable<ScreenDto>> GetAllScreensAsync();
        Task<ScreenDto?> GetScreenByIdAsync(int id);
        Task<ScreenDto> CreateScreenAsync(CreateScreenDto createDto);
    }
}