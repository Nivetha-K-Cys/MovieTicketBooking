const AppState = {
    currentView: 'home',
    user: null,
    selectedMovie: null,
    selectedShow: null,
    selectedSeats: [],
    movies: [
        { id: 1, title: "Interstellar", genre: "Sci-Fi / Adventure", duration: 169, language: "English", price: 250, description: "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival." },
        { id: 2, title: "Inception", genre: "Action / Sci-Fi", duration: 148, language: "English", price: 220, description: "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task." },
        { id: 3, title: "Vikram", genre: "Action / Thriller", duration: 174, language: "Tamil", price: 200, description: "A special investigator traces a series of masked murders committed by a ruthless drug syndicate." }
    ],
    theatres: [
        { id: 1, name: "PVR Cinemas, Madurai", screen: "Audi 1 - 4K Dolby Atmos" },
        { id: 2, name: "AGS Cinemas, Madurai", screen: "Screen 2 - Laser Projection" }
    ],
    shows: [
        { id: 1, movieId: 1, theatreId: 1, date: "2026-06-10", time: "10:00 AM" },
        { id: 2, movieId: 1, theatreId: 2, date: "2026-06-10", time: "02:30 PM" },
        { id: 3, movieId: 2, theatreId: 1, date: "2026-06-10", time: "06:00 PM" },
        { id: 4, movieId: 3, theatreId: 2, date: "2026-06-10", time: "09:00 PM" }
    ],
    bookedSeatsData: {
        "1": [3, 4, 12, 15],
        "2": [7, 8, 9]
    },
    myBookings: []
};
