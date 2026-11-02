using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MovieTicketBooking.Models;

namespace MovieTicketBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Theater> Theaters { get; set; }

        public DbSet<Screen> Screens { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<ShowSeat> ShowSeats { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.DurationMinutes).IsRequired();
                entity.Property(e => e.ReleaseDate).HasColumnType("date");
                entity.Property(e => e.Language).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Genre).IsRequired().HasMaxLength(50);

            
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