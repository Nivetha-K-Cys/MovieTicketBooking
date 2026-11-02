namespace MovieTicketBooking.Dtos
{
    public class ScreenDto
    {
        public int ScreenId { get; set; }
        public string ScreenName { get; set; } = string.Empty;
        public int TheaterId { get; set; }
        public string TheaterName { get; set; } = string.Empty;
    }

    public class CreateScreenDto
    {
        public string ScreenName { get; set; } = string.Empty;
        public int TheaterId { get; set; }
    }
}