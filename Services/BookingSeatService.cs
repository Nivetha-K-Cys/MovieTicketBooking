using MovieTicketBooking.DTOs;
using MovieTicketBooking.Repositories.Interfaces;
using MovieTicketBooking.Services.Interfaces;

namespace MovieTicketBooking.Services
{
    public class BookingSeatService : IBookingSeatService
    {
        private readonly IBookingSeatRepository _bookingSeatRepository;

        public BookingSeatService(IBookingSeatRepository bookingSeatRepository)
        {
            _bookingSeatRepository = bookingSeatRepository;
        }

        public async Task<List<BookingSeatResponseDto>> GetSeatsForBookingAsync(int bookingId)
        {
            var bookingSeats = await _bookingSeatRepository.GetSeatsByBookingIdAsync(bookingId);

            return bookingSeats.Select(bs => new BookingSeatResponseDto
            {
                BookingSeatId = bs.BookingSeatId,
                SeatId = bs.SeatId,
                Price = bs.Price
            }).ToList();
        }
    }
}