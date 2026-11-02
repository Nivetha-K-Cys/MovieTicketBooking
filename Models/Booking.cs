using System.ComponentModel.DataAnnotations.Schema;
using MovieTicketBooking.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int ShowId { get; set; }

    // Navigation Property for Show
    public Show Show { get; set; } = null!;

    public DateTime BookingTime { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = "Confirmed";

    // Navigation Property for BookingSeats (One-to-Many)
    public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();
}