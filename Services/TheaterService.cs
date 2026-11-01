using MovieTicketBooking.DTOs;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories;

namespace MovieTicketBooking.Services
{
    public class TheaterService : ITheaterService
    {
        private readonly ITheaterRepository _theaterRepository;

        public TheaterService(ITheaterRepository theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public async Task<IEnumerable<TheaterDto>> GetAllTheatersAsync()
        {
            var theaters = await _theaterRepository.GetAllTheatersAsync();
            return theaters.Select(t => new TheaterDto
            {
                TheaterId = t.TheaterId,
                Name = t.Name,
                Location = t.Location
            });
        }

        public async Task<TheaterDto?> GetTheaterByIdAsync(int id)
        {
            var t = await _theaterRepository.GetTheaterByIdAsync(id);
            if (t == null) return null;

            return new TheaterDto
            {
                TheaterId = t.TheaterId,
                Name = t.Name,
                Location = t.Location
            };
        }

        public async Task AddTheaterAsync(TheaterDto theaterDto)
        {
            var theater = new Theater
            {
                Name = theaterDto.Name,
                Location = theaterDto.Location
            };
            await _theaterRepository.AddTheaterAsync(theater);
        }

        public async Task UpdateTheaterAsync(int id, TheaterDto theaterDto)
        {
            var theater = await _theaterRepository.GetTheaterByIdAsync(id);
            if (theater != null)
            {
                theater.Name = theaterDto.Name;
                theater.Location = theaterDto.Location;
                await _theaterRepository.UpdateTheaterAsync(theater);
            }
        }

        public async Task DeleteTheaterAsync(int id)
        {
            await _theaterRepository.DeleteTheaterAsync(id);
        }
    }
}