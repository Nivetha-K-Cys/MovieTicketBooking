using MovieTicketBooking.Data;
using MovieTicketBooking.Models;
using MovieTicketBooking.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MovieTicketBooking.Services
{
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;

        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Intha edathula paste pannikonga:
        public async Task<bool> CreateBulkSeatsAsync(int screenId, List<MovieTicketBooking.DTOs.Seats.CreateSeatDto> seatRequests)
        {
            var screen = await _context.Screens.FindAsync(screenId);
            if (screen == null) return false;

            var seats = seatRequests.Select(dto => new Seat
            {
                ScreenId = screenId,
                RowName = dto.RowName,
                SeatNumber = dto.SeatNumber,
                SeatType = dto.SeatType,
                Price = dto.Price
            }).ToList();

            _context.Seats.AddRange(seats);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Seat>> GetSeatsByScreenIdAsync(int screenId)
        {
            return await _context.Seats.Where(s => s.ScreenId == screenId).ToListAsync();
        }

        public async Task<Seat> CreateSeatAsync(Seat seat)
        {
            _context.Seats.Add(seat);
            await _context.SaveChangesAsync();
            return seat;
        }
    }
}