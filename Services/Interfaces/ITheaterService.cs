using MovieTicketBooking.DTOs;

namespace MovieTicketBooking.Services
{
    public interface ITheaterService
    {
        Task<IEnumerable<TheaterDto>> GetAllTheatersAsync();
        Task<TheaterDto?> GetTheaterByIdAsync(int id);
        Task AddTheaterAsync(TheaterDto theaterDto);
        Task UpdateTheaterAsync(int id, TheaterDto theaterDto);
        Task DeleteTheaterAsync(int id);
    }
}