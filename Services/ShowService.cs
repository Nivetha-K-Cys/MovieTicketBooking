using MovieTicketBooking.DTOs.Shows;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Services
{
    public class ShowService : IShowService
    {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<IEnumerable<ShowDto>> GetAllShowsAsync()
        {
            var shows = await _showRepository.GetAllShowsAsync();
            return shows.Select(s => new ShowDto
            {
                ShowId = s.ShowId,
                MovieId = s.MovieId,
                MovieTitle = s.Movie?.Title,
                ScreenId = s.ScreenId,
                ScreenName = s.Screen?.ScreenName,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                TicketPrice = s.TicketPrice
            });
        }

        public async Task<ShowDto?> GetShowByIdAsync(int id)
        {
            var s = await _showRepository.GetShowByIdAsync(id);
            if (s == null) return null;

            return new ShowDto
            {
                ShowId = s.ShowId,
                MovieId = s.MovieId,
                MovieTitle = s.Movie?.Title,
                ScreenId = s.ScreenId,
                ScreenName = s.Screen?.ScreenName,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                TicketPrice = s.TicketPrice
            };
        }

        public async Task<IEnumerable<ShowDto>> GetShowsByMovieIdAsync(int movieId)
        {
            var shows = await _showRepository.GetShowsByMovieIdAsync(movieId);
            return shows.Select(s => new ShowDto
            {
                ShowId = s.ShowId,
                MovieId = s.MovieId,
                MovieTitle = s.Movie?.Title,
                ScreenId = s.ScreenId,
                ScreenName = s.Screen?.ScreenName,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                TicketPrice = s.TicketPrice
            });
        }

        public async Task<ShowDto> CreateShowAsync(CreateShowDto dto)
        {
            var show = new Show
            {
                MovieId = dto.MovieId,
                ScreenId = dto.ScreenId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TicketPrice = dto.TicketPrice
            };

            var created = await _showRepository.CreateShowAsync(show);

            return new ShowDto
            {
                ShowId = created.ShowId,
                MovieId = created.MovieId,
                ScreenId = created.ScreenId,
                StartTime = created.StartTime,
                EndTime = created.EndTime,
                TicketPrice = created.TicketPrice
            };
        }

        public async Task<bool> UpdateShowAsync(int id, CreateShowDto dto)
        {
            var show = new Show
            {
                MovieId = dto.MovieId,
                ScreenId = dto.ScreenId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TicketPrice = dto.TicketPrice
            };

            return await _showRepository.UpdateShowAsync(id, show);
        }

        public async Task<bool> DeleteShowAsync(int id)
        {
            return await _showRepository.DeleteShowAsync(id);
        }
    }
}