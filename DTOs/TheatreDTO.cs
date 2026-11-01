using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.DTOs
{
    public class TheaterDto
    {
        public int TheaterId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;
    }
}