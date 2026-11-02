using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories.Interfaces
{
    public interface IShowSeatRepository
    {
        Task<IEnumerable<ShowSeat>> GetByShowIdAsync(int showId);
        Task<ShowSeat?> GetByIdAsync(int id);
        Task AddAsync(ShowSeat showSeat);
        Task UpdateAsync(ShowSeat showSeat);
        Task DeleteAsync(int id);
    }
}