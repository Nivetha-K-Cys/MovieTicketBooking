using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Data;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories.Interfaces;

namespace MovieTicketBooking.Repositories
{
    public class ShowSeatRepository : IShowSeatRepository
    {
        private readonly ApplicationDbContext _context;

        public ShowSeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShowSeat>> GetByShowIdAsync(int showId)
        {
            return await _context.ShowSeats
                .Include(s => s.Seat)
                .Where(s => s.ShowId == showId)
                .ToListAsync();
        }

        public async Task<ShowSeat?> GetByIdAsync(int id)
        {
            return await _context.ShowSeats
                .Include(s => s.Seat)
                .FirstOrDefaultAsync(s => s.ShowSeatId == id);
        }

        public async Task AddAsync(ShowSeat showSeat)
        {
            await _context.ShowSeats.AddAsync(showSeat);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ShowSeat showSeat)
        {
            _context.ShowSeats.Update(showSeat);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var showSeat = await _context.ShowSeats.FindAsync(id);
            if (showSeat != null)
            {
                _context.ShowSeats.Remove(showSeat);
                await _context.SaveChangesAsync();
            }
        }
    }
}