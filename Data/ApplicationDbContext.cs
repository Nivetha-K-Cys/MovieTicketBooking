using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Data
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        // Fallback connection string
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=.\SQLEXPRESS;Database=MovieTicketBooking;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Theater> Theaters { get; set; } = null!;
        public DbSet<Screen> Screens { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<Show> Shows { get; set; } = null!;
        public DbSet<ShowSeat> ShowSeats { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingSeat> BookingSeats { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.DurationMinutes)
                    .IsRequired();

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.Price)
                    .HasPrecision(18, 2);
            });

            modelBuilder.Entity<ShowSeat>(entity =>
            {
                entity.HasOne(s => s.Show)
                    .WithMany(sh => sh.ShowSeats)
                    .HasForeignKey(s => s.ShowId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Seat)
                    .WithMany()
                    .HasForeignKey(s => s.SeatId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}