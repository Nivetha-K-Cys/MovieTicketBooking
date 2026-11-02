using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketBooking.Models;

public class BookingSeat
{
    [Key]
    public int BookingSeatId { get; set; }

    public int BookingId { get; set; }
    [ForeignKey("BookingId")]
    // Navigation Property to Booking
    public Booking Booking { get; set; } = null!;

    public int SeatId { get; set; }
    [ForeignKey("SeatId")]
    // Navigation Property to Seat
    public Seat Seat { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
}