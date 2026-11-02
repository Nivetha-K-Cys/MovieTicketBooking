using MovieTicketBooking.Models;

namespace MovieTicketBooking.Interfaces
{
    public interface IShowRepository
    {
        Task<IEnumerable<Show>> GetAllShowsAsync();
        Task<Show?> GetShowByIdAsync(int id);
        Task<IEnumerable<Show>> GetShowsByMovieIdAsync(int movieId);
        Task<Show> CreateShowAsync(Show show);
        Task<bool> UpdateShowAsync(int id, Show show);
        Task<bool> DeleteShowAsync(int id);
    }
}