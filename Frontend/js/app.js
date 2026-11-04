const MovieDetailsComponent = {
    async render() {
        const container = document.getElementById('movie-details-content');
        if (!container || !AppState.selectedMovie) return;

        container.innerHTML = "<p>Loading movie details from backend...</p>";

        try {
            // Selected movie-oda ID-ai vachi backend-ilirunthu complete details edukkurom
            const movieId = AppState.selectedMovie.id;
            const response = await fetch(`http://localhost:5101/api/movies/${movieId}`);
            
            if (!response.ok) {
                throw new Error('Failed to fetch movie details');
            }

            const m = await response.json();
            
            // Backend-la irunthu vantha data-ai frontend-la display panrathu
            container.innerHTML = `
                <h2>${m.title}</h2>
                <p><strong>Genre:</strong> ${m.genre || 'N/A'}</p>
                <p><strong>Duration:</strong> ${m.duration || 'N/A'} minutes</p>
                <p><strong>Language:</strong> ${m.language || 'N/A'}</p>
                <p><strong>Ticket Price:</strong> ₹${m.price || 0}</p>
                <p style="margin-top:15px;"><strong>Description:</strong> ${m.description || 'No description available.'}</p>
                <button class="btn-primary" style="margin-top:20px;" onclick="Router.navigateTo('shows')">Select Show Timings</button>
            `;

        } catch (error) {
            console.error('Error:', error);
            container.innerHTML = "<p style='color:red;'>Backend-ilirunthu movie details edukka mudiyala. Backend endpoint check pannunga!</p>";
        }
    }
};