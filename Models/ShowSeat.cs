using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBooking.Models
{
    public class ShowSeat
    {
        [Key]
        public int ShowSeatId { get; set; }

        [Required]
        public int ShowId { get; set; }
        [ForeignKey("ShowId")]
        public Show? Show { get; set; }

        [Required]
        public int SeatId { get; set; }
        [ForeignKey("SeatId")]
        public Seat? Seat { get; set; }

        public string RowName { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public string SeatType { get; set; } = string.Empty;

        public bool IsBooked { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}