using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Data;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly ApplicationDbContext _context;

        public SeatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByScreenIdAsync(int screenId)
        {
            return await _context.Seats.Where(s => s.ScreenId == screenId).ToListAsync();
        }

        public async Task<Seat?> GetSeatByIdAsync(int id)
        {
            return await _context.Seats.FindAsync(id);
        }

        public async Task<Seat> AddSeatAsync(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
            return seat;
        }

        public async Task<IEnumerable<Seat>> AddRangeAsync(IEnumerable<Seat> seats)
        {
            _context.Seats.AddRange(seats);
            await _context.SaveChangesAsync();
            return seats;
        }
    }
}