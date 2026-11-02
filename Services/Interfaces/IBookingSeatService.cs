using MovieTicketBooking.DTOs;

namespace MovieTicketBooking.Services.Interfaces
{
    public interface IBookingSeatService
    {
        Task<List<BookingSeatResponseDto>> GetSeatsForBookingAsync(int bookingId);
    }
}