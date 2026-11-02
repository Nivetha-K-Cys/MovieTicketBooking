using MovieTicketBooking.Models;

namespace MovieTicketBooking.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Task<List<ShowSeat>> GetShowSeatsByIdsAsync(List<int> showSeatIds);
        Task<Booking> AddAsync(Booking booking);
    }
}