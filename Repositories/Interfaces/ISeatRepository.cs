using MovieTicketBooking.Models;

namespace MovieTicketBooking.Interfaces
{
    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetSeatsByScreenIdAsync(int screenId);
        Task<Seat?> GetSeatByIdAsync(int id);
        Task<Seat> AddSeatAsync(Seat seat);
        Task<IEnumerable<Seat>> AddRangeAsync(IEnumerable<Seat> seats);
    }
}