using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBooking.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie? Movie { get; set; }

        [Required]
        public int ScreenId { get; set; }
        [ForeignKey("ScreenId")]
        public Screen? Screen { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TicketPrice { get; set; }

        public ICollection<ShowSeat>? ShowSeats { get; set; }
    }
}