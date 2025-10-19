# Movie Ticket Booking System in C#

This is a **console-based Movie Ticket Booking application** written in C#.  
It allows users to **view movies, book tickets, cancel bookings, and view booking details** using a simple command-line interface. This project demonstrates **C# classes, object-oriented programming (OOP) concepts, lists, and basic console I/O**.

## Features
- View available movies and showtimes.
- Book tickets for selected movies.
- Cancel tickets by booking ID.
- View booking details.
- Simple command-line interface for interaction.

## Commands
- `viewmovies` : Displays all available movies with timings.
- `book <movieId> <numberOfTickets>` : Books tickets for a movie.
- `cancel <bookingId>` : Cancels a ticket booking by its ID.
- `viewbookings` : Shows all current bookings.
- `quit` : Exits the application.

## Example Usage
```text
> viewmovies
Movie 1: Avengers: Endgame - 7:00 PM
Movie 2: Inception - 9:00 PM

> book 1 2
Booking successful! Booking ID: 101, Movie: Avengers: Endgame, Tickets: 2

> viewbookings
Booking ID: 101, Movie: Avengers: Endgame, Tickets: 2

> cancel 101
Booking cancelled: ID 101

> quit
Goodbye!
