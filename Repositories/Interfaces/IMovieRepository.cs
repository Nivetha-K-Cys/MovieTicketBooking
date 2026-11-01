using MovieTicketBooking.Models;

namespace MovieTicketBooking.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> SearchByTitleAsync(string title);
        Task<Movie> AddAsync(Movie movie);
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}