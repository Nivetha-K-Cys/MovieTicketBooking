using MovieTicketBooking.Dtos;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return movies.Select(MapToResponse);
        }

        public async Task<MovieResponse?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie == null ? null : MapToResponse(movie);
        }

        public async Task<IEnumerable<MovieResponse>> SearchMoviesByTitleAsync(string title)
        {
            var movies = await _movieRepository.SearchByTitleAsync(title);
            return movies.Select(MapToResponse);
        }

        public async Task<MovieResponse> CreateMovieAsync(CreateMovieRequest request)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                DurationMinutes = request.DurationMinutes,
                ReleaseDate = request.ReleaseDate,
                Language = request.Language,
                Genre = request.Genre
            };

            var created = await _movieRepository.AddAsync(movie);
            return MapToResponse(created);
        }

        public async Task<bool> UpdateMovieAsync(int id, UpdateMovieRequest request)
        {
            var existing = await _movieRepository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Title = request.Title;
            existing.Description = request.Description;
            existing.DurationMinutes = request.DurationMinutes;
            existing.ReleaseDate = request.ReleaseDate;
            existing.Language = request.Language;
            existing.Genre = request.Genre;

            return await _movieRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteAsync(id);
        }

        private static MovieResponse MapToResponse(Movie m) => new MovieResponse
        {
            MovieId = m.MovieId,
            Title = m.Title,
            Description = m.Description,
            DurationMinutes = m.DurationMinutes,
            ReleaseDate = m.ReleaseDate,
            Language = m.Language,
            Genre = m.Genre
        };
    }
}