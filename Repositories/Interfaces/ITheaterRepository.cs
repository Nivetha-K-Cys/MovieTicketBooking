using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories
{
    public interface ITheaterRepository
    {
        Task<IEnumerable<Theater>> GetAllTheatersAsync();
        Task<Theater?> GetTheaterByIdAsync(int id);
        Task AddTheaterAsync(Theater theater);
        Task UpdateTheaterAsync(Theater theater);
        Task DeleteTheaterAsync(int id);
    }
}