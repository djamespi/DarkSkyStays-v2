namespace DarkSkyStays.Models;

public sealed record TourReservation(
    string Reference,
    int TourId,
    string TourName,
    DateOnly Date,
    int Guests,
    int TotalPrice);
