const Router = {
    async loadComponent(viewName) {
        try {
            const response = await fetch(`components/${viewName}.html`);
            if (!response.ok) throw new Error(`Could not load ${viewName}`);
            return await response.text();
        } catch (error) {
            console.error(error);
            return `<div style="padding: 20px; color: red;">Error loading view.</div>`;
        }
    },

    async navigateTo(viewName) {
        AppState.currentView = viewName;
        const container = document.getElementById('main-view-container');
        container.innerHTML = await this.loadComponent(viewName);

        document.querySelectorAll('.nav-links a').forEach(a => a.classList.remove('active'));
        if (viewName === 'home') document.getElementById('nav-home')?.classList.add('active');
        if (viewName === 'movies') document.getElementById('nav-movies')?.classList.add('active');
        if (viewName === 'my-bookings') document.getElementById('nav-bookings')?.classList.add('active');
        if (viewName === 'admin') document.getElementById('nav-admin')?.classList.add('active');

        this.initViewLogic(viewName);
        window.scrollTo(0, 0);
    },

    initViewLogic(viewName) {
        switch (viewName) {
            case 'home': HomeComponent.render(); break;
            case 'movies': MoviesComponent.render(); break;
            case 'movie-details': MovieDetailsComponent.render(); break;
            case 'shows': ShowsComponent.render(); break;
            case 'seats': SeatComponent.render(); break;
            case 'booking': BookingComponent.render(); break;
            case 'my-bookings': MyBookingsComponent.render(); break;
            case 'admin': AdminComponent.render(); break;
        }
    }
};
