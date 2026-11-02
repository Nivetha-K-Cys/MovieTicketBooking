using MovieTicketBooking.DTOs;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories;
using MovieTicketBooking.Repositories.Interfaces;

namespace MovieTicketBooking.Services
{
    public class ShowSeatService : IShowSeatService
    {
        private readonly IShowSeatRepository _showSeatRepository;

        public ShowSeatService(IShowSeatRepository showSeatRepository)
        {
            _showSeatRepository = showSeatRepository;
        }

        public async Task<IEnumerable<ShowSeatDto>> GetSeatsByShowIdAsync(int showId)
        {
            var seats = await _showSeatRepository.GetByShowIdAsync(showId);
            return seats.Select(s => new ShowSeatDto
            {
                ShowSeatId = s.ShowSeatId,
                ShowId = s.ShowId,
                SeatId = s.SeatId,
                RowName = s.RowName ?? string.Empty,
                SeatNumber = s.SeatNumber,
                SeatType = s.SeatType ?? string.Empty,
                IsBooked = s.IsBooked,
                Price = s.Price
            });
        }

        public async Task<ShowSeatDto?> GetByIdAsync(int id)
        {
            var s = await _showSeatRepository.GetByIdAsync(id);
            if (s == null) return null;

            return new ShowSeatDto
            {
                ShowSeatId = s.ShowSeatId,
                ShowId = s.ShowId,
                SeatId = s.SeatId,
                RowName = s.RowName ?? string.Empty,
                SeatNumber = s.SeatNumber,
                SeatType = s.SeatType ?? string.Empty,
                IsBooked = s.IsBooked,
                Price = s.Price
            };
        }

        public async Task AddAsync(ShowSeatDto showSeatDto)
        {
            var showSeat = new ShowSeat
            {
                ShowId = showSeatDto.ShowId,
                SeatId = showSeatDto.SeatId,
                RowName = showSeatDto.RowName,
                SeatNumber = showSeatDto.SeatNumber,
                SeatType = showSeatDto.SeatType,
                IsBooked = showSeatDto.IsBooked,
                Price = showSeatDto.Price
            };
            await _showSeatRepository.AddAsync(showSeat);
        }

        public async Task UpdateAsync(ShowSeatDto showSeatDto)
        {
            var showSeat = await _showSeatRepository.GetByIdAsync(showSeatDto.ShowSeatId);
            if (showSeat != null)
            {
                showSeat.ShowId = showSeatDto.ShowId;
                showSeat.SeatId = showSeatDto.SeatId;
                showSeat.RowName = showSeatDto.RowName;
                showSeat.SeatNumber = showSeatDto.SeatNumber;
                showSeat.SeatType = showSeatDto.SeatType;
                showSeat.IsBooked = showSeatDto.IsBooked;
                showSeat.Price = showSeatDto.Price;
                await _showSeatRepository.UpdateAsync(showSeat);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _showSeatRepository.DeleteAsync(id);
        }

        public async Task GenerateSeatsForShowAsync(int showId, int screenId)
        {
            await Task.CompletedTask;
        }

        public async Task UpdateSeatBookingStatusAsync(int showSeatId, bool isBooked)
        {
            var showSeat = await _showSeatRepository.GetByIdAsync(showSeatId);
            if (showSeat != null)
            {
                showSeat.IsBooked = isBooked;
                await _showSeatRepository.UpdateAsync(showSeat);
            }
        }
    }
}