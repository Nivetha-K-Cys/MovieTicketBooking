using MovieTicketBooking.Models;

namespace MovieTicketBooking.Interfaces
{
    public interface IScreenRepository
    {
        Task<IEnumerable<Screen>> GetAllScreensAsync();
        Task<Screen?> GetScreenByIdAsync(int id);
        Task<Screen> AddScreenAsync(Screen screen);
    }
}