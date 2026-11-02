using MovieTicketBooking.DTOs;

namespace MovieTicketBooking.Services
{
    public interface IShowSeatService
    {
        Task<IEnumerable<ShowSeatDto>> GetSeatsByShowIdAsync(int showId);
        Task<ShowSeatDto?> GetByIdAsync(int id);
        Task AddAsync(ShowSeatDto showSeatDto);
        Task UpdateAsync(ShowSeatDto showSeatDto);
        Task DeleteAsync(int id);
        Task GenerateSeatsForShowAsync(int showId, int screenId);
        Task UpdateSeatBookingStatusAsync(int showSeatId, bool isBooked);
    }
}