
using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Data;
using MovieTicketBooking.Repositories.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories
{
    public class ShowRepository : IShowRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Show>> GetAllShowsAsync()
        {
            return await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                .ToListAsync();
        }

        public async Task<Show?> GetShowByIdAsync(int id)
        {
            return await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                .FirstOrDefaultAsync(s => s.ShowId == id);
        }

        public async Task<IEnumerable<Show>> GetShowsByMovieIdAsync(int movieId)
        {
            return await _context.Shows
                .Include(s => s.Movie)
                .Include(s => s.Screen)
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }

        public async Task<Show> CreateShowAsync(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return show;
        }

        public async Task<bool> UpdateShowAsync(int id, Show show)
        {
            var existing = await _context.Shows.FindAsync(id);

            if (existing == null)
                return false;

            existing.MovieId = show.MovieId;
            existing.ScreenId = show.ScreenId;
            existing.StartTime = show.StartTime;
            existing.EndTime = show.EndTime;
            existing.TicketPrice = show.TicketPrice;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteShowAsync(int id)
        {
            var show = await _context.Shows.FindAsync(id);

            if (show == null)
                return false;

            _context.Shows.Remove(show);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
