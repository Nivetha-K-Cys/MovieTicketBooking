using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTicketBooking.Models
{
    public class Screen
    {
        [Key]
        public int ScreenId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ScreenName { get; set; } = string.Empty;

        // Foreign Key for Theater
        public int TheaterId { get; set; }

        [ForeignKey("TheaterId")]
        public Theater? Theater { get; set; }
    }
}