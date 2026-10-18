using DarkSkyStays.Models;

namespace DarkSkyStays.Services;

/// <summary>Source tour listings and demo reservations held only in browser memory.</summary>
public sealed class SampleTourService
{
    private readonly List<TourReservation> reservations = [];

    public IReadOnlyList<Tour> Tours { get; } = Array.AsReadOnly<Tour>(
    [
        new(1, "Milky Way Core Photography Night", "Mt. Pulag, Benguet",
            "9:30 PM – 2:00 AM", 2500, "Dr. Lena Ocampo",
            "https://images.unsplash.com/photo-1623390003557-1b1c4f7c9a4e?auto=format&fit=crop&w=1400&q=80"),
        new(2, "Telescope Safari: Deep Sky Objects", "Sabtang, Batanes",
            "8:00 PM – 11:30 PM", 1800, "Paolo Cabugao",
            "https://images.unsplash.com/photo-1608549785765-036974ba067d?auto=format&fit=crop&w=1400&q=80"),
        new(3, "Island-Hopping Star Cruise", "Balabac, Palawan",
            "7:00 PM – 12:00 AM", 3500, "Aira Dela Cruz",
            "https://images.unsplash.com/photo-1738004659538-7648e412b3df?auto=format&fit=crop&w=1400&q=80")
    ]);

    public IReadOnlyList<TourReservation> Reservations => reservations.AsReadOnly();

    public TourReservation Reserve(int tourId, DateOnly date, int guests)
    {
        var tour = Tours.FirstOrDefault(tour => tour.Id == tourId)
            ?? throw new ArgumentException("Choose an available sample tour.", nameof(tourId));

        if (date < DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentOutOfRangeException(nameof(date), "Choose today or a future date.");
        }

        if (guests is < 1 or > 8)
        {
            throw new ArgumentOutOfRangeException(nameof(guests), "Choose between 1 and 8 guests.");
        }

        var reservation = new TourReservation(
            $"DEMO-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}",
            tour.Id, tour.Name, date, guests, tour.PricePerPerson * guests);
        reservations.Add(reservation);
        return reservation;
    }
}
