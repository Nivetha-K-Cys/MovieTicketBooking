using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories.Interfaces
{
    public interface IBookingSeatRepository
    {
        Task<List<BookingSeat>> GetSeatsByBookingIdAsync(int bookingId);
        Task AddRangeAsync(IEnumerable<BookingSeat> bookingSeats);
    }
}