using MovieTicketBooking.Data;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieTicketBooking.Repositories
{
    // MUST implement IScreenRepository, NOT IScreenService
    public class ScreenRepository : IScreenRepository
    {
        private readonly ApplicationDbContext _context;

        public ScreenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Screen>> GetAllScreensAsync()
        {
            return await _context.Screens.Include(s => s.Theater).ToListAsync();
        }

        public async Task<Screen?> GetScreenByIdAsync(int id)
        {
            return await _context.Screens.Include(s => s.Theater).FirstOrDefaultAsync(s => s.ScreenId == id);
        }

        public async Task<Screen> AddScreenAsync(Screen screen)
        {
            _context.Screens.Add(screen);
            await _context.SaveChangesAsync();
            return screen;
        }
    }
}