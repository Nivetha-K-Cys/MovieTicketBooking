
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieTicketBooking.Data;
using MovieTicketBooking.Interfaces;
using MovieTicketBooking.Models;
using MovieTicketBooking.Repositories;
using MovieTicketBooking.Repositories.Interfaces;
using MovieTicketBooking.Services;
using MovieTicketBooking.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// DATABASE CONNECTION
const string connectionString =
    @"Server=.\SQLEXPRESS;Database=MovieTicketBooking;Trusted_Connection=True;TrustServerCertificate=True;";

Console.WriteLine("Database connection configuration loaded.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

// JWT CONFIGURATION
var jwtSettings = builder.Configuration.GetSection("Jwt");

var jwtKey = jwtSettings["Key"]
    ?? "MovieTicketBooking_Development_Key_1234567890";

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["Issuer"]
                    ?? "MovieTicketBookingAPI",

                ValidAudience = jwtSettings["Audience"]
                    ?? "MovieTicketBookingClient",

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtKey)
                ),

                RoleClaimType =
                    System.Security.Claims.ClaimTypes.Role
            };
    });

// CONTROLLERS AND SWAGGER
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MOVIE
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

// THEATER
builder.Services.AddScoped<ITheaterRepository, TheaterRepository>();
builder.Services.AddScoped<ITheaterService, TheaterService>();

// SCREEN
builder.Services.AddScoped<IScreenRepository, ScreenRepository>();
builder.Services.AddScoped<IScreenService, ScreenService>();

// SEAT
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ISeatService, SeatService>();

// SHOW
builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddScoped<IShowService, ShowService>();

// SHOW SEAT
builder.Services.AddScoped<IShowSeatRepository, ShowSeatRepository>();
builder.Services.AddScoped<IShowSeatService, ShowSeatService>();

// BOOKING
builder.Services.AddScoped<
    MovieTicketBooking.Repositories.Interfaces.IBookingRepository,
    BookingRepository>();

builder.Services.AddScoped<IBookingService, BookingService>();

// BOOKING SEAT
builder.Services.AddScoped<IBookingSeatRepository, BookingSeatRepository>();
builder.Services.AddScoped<IBookingSeatService, BookingSeatService>();

// USER
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();

var app = builder.Build();

// CHECK DATABASE CONNECTION AND ADMIN SETUP
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        // Test database connection
        bool canConnect = await dbContext.Database.CanConnectAsync();

        if (!canConnect)
        {
            throw new Exception(
                "Cannot connect to MovieTicketBookingDB. Check SQL Server and database name.");
        }

        Console.WriteLine("Database connected successfully!");

        var userRepository = scope.ServiceProvider
            .GetRequiredService<IUserRepository>();

        Console.WriteLine("===== ADMIN SETUP =====");

        Console.Write("Enter Admin Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Admin Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter Admin Password: ");
        string password = Console.ReadLine() ?? "";

        if (!string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrWhiteSpace(email) &&
            !string.IsNullOrWhiteSpace(password))
        {
            var existingAdmin =
                await userRepository.GetByEmailAsync(email);

            if (existingAdmin == null)
            {
                var admin = new User
                {
                    Username = name,
                    Email = email,
                    PasswordHash =
                        BCrypt.Net.BCrypt.HashPassword(password),
                    Role = "Admin"
                };

                await userRepository.AddAsync(admin);

                Console.WriteLine("Admin created successfully!");
            }
            else
            {
                Console.WriteLine(
                    "This email already exists. Admin not created.");
            }
        }
        else
        {
            Console.WriteLine("Admin details cannot be empty.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("DATABASE / ADMIN SETUP ERROR:");
        Console.WriteLine(ex.Message);
        throw;
    }
}

// MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
