using MovieTicketBooking.DTOs.Shows;

namespace MovieTicketBooking.Interfaces
{
    public interface IShowService
    {
        Task<IEnumerable<ShowDto>> GetAllShowsAsync();
        Task<ShowDto?> GetShowByIdAsync(int id);
        Task<IEnumerable<ShowDto>> GetShowsByMovieIdAsync(int movieId);
        Task<ShowDto> CreateShowAsync(CreateShowDto dto);
        Task<bool> UpdateShowAsync(int id, CreateShowDto dto);
        Task<bool> DeleteShowAsync(int id);
    }
}