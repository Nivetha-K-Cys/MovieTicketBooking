using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        public string RowName { get; set; } = string.Empty;
        public string SeatNumber { get; set; } = string.Empty;
        public string SeatType { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int ScreenId { get; set; }

        // Ithu thaan antha Navigation Property - romba mukkiyam!
        public Screen Screen { get; set; } = null!;

       
    }
}