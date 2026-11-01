using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Data;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly ApplicationDbContext _context;

        public TheaterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Theater>> GetAllTheatersAsync()
        {
            return await _context.Theaters.ToListAsync();
        }

        public async Task<Theater?> GetTheaterByIdAsync(int id)
        {
            return await _context.Theaters.FindAsync(id);
        }

        public async Task AddTheaterAsync(Theater theater)
        {
            await _context.Theaters.AddAsync(theater);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTheaterAsync(Theater theater)
        {
            _context.Theaters.Update(theater);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTheaterAsync(int id)
        {
            var theater = await _context.Theaters.FindAsync(id);
            if (theater != null)
            {
                _context.Theaters.Remove(theater);
                await _context.SaveChangesAsync();
            }
        }
    }
}