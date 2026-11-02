using MovieTicketBooking.DTOs;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<Booking?> CreateBookingAsync(CreateBookingDto dto);
    }
}