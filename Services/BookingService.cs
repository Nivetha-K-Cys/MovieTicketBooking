using MovieTicketBooking.DTOs;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories.Interfaces;
using MovieTicketBooking.Services.Interfaces;

namespace MovieTicketBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking?> CreateBookingAsync(CreateBookingDto dto)
        {
            var showSeats = await _bookingRepository.GetShowSeatsByIdsAsync(dto.ShowSeatIds);

            if (showSeats.Any(s => s.Status == "Booked"))
            {
                return null;
            }

            decimal totalAmount = showSeats.Sum(s => s.Price);

            var booking = new Booking
            {
                ShowId = dto.ShowId,
                BookingTime = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Confirmed",
                BookingSeats = showSeats.Select(s => new BookingSeat
                {
                    SeatId = s.SeatId,
                    Price = s.Price
                }).ToList()
            };

            foreach (var seat in showSeats)
            {
                seat.Status = "Booked";
            }

            return await _bookingRepository.AddAsync(booking);
        }
    }
}