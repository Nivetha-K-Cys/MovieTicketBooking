namespace MovieTicketBooking.DTOs.Seats
{
    public class CreateSeatDto
    {
        public string RowName { get; set; } = string.Empty;
        public string SeatNumber { get; set; } = string.Empty;
        public string SeatType { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}