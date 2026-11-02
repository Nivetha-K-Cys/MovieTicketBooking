using MovieTicketBooking.Models;

namespace MovieTicketBooking.Interfaces
{
    public interface ISeatService
    {
        // Intha edathula paste pannikonga:
        Task<bool> CreateBulkSeatsAsync(int screenId, List<MovieTicketBooking.DTOs.Seats.CreateSeatDto> seatRequests);
        Task<IEnumerable<Seat>> GetSeatsByScreenIdAsync(int screenId);
        Task<Seat> CreateSeatAsync(Seat seat);
    }
}