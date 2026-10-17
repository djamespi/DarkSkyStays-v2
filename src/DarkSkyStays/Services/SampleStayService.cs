using DarkSkyStays.Models;

namespace DarkSkyStays.Services;

/// <summary>Source listings with illustrative amenity attributes for browser-only filters.</summary>
public sealed class SampleStayService
{
    public const string HeroImageUrl = "https://images.unsplash.com/photo-1623390003557-1b1c4f7c9a4e?auto=format&fit=crop&w=1400&q=80";

    public IReadOnlyList<Stay> Stays { get; } = Array.AsReadOnly<Stay>(
    [
        new(1, "Sagada Pine Cabin", "Sagada, Mountain Province", 4500,
            "https://images.unsplash.com/photo-1786676886005-b819eeee3b32?auto=format&fit=crop&w=1400&q=80",
            "Cordillera highlands", 2, 21.6, StayAmenity.HotTub | StayAmenity.Telescope | StayAmenity.RedLightOnly),
        new(2, "Batanes Stone House", "Sabtang, Batanes", 6800,
            "https://images.unsplash.com/photo-1738004659538-7648e412b3df?auto=format&fit=crop&w=1400&q=80",
            "Darkest in the country", 1, 21.9, StayAmenity.Telescope | StayAmenity.RedLightOnly),
        new(3, "Nipa & Comet Lodge", "Balabac, Palawan", 5900,
            "https://images.unsplash.com/photo-1695413120140-07575da6eab5?auto=format&fit=crop&w=1400&q=80",
            "Remote island skies", 1, 21.8, StayAmenity.GlassCeiling | StayAmenity.RedLightOnly),
        new(4, "A-Frame Nebula", "Mt. Pulag, Benguet", 3800,
            "https://images.unsplash.com/photo-1771240462924-386d887c1df6?auto=format&fit=crop&w=1400&q=80",
            "Sea of clouds & stars", 2, 21.7, StayAmenity.Telescope | StayAmenity.GlassCeiling),
        new(5, "Mirror Lake House", "Lake Sebu, South Cotabato", 3200,
            "https://images.unsplash.com/photo-1774444487684-a796af0c2841?auto=format&fit=crop&w=1400&q=80",
            "Reflective skies", 2, 21.5, StayAmenity.HotTub | StayAmenity.GlassCeiling),
        new(6, "Siargao Coconut Village", "Del Carmen, Siargao", 2500,
            "https://images.unsplash.com/photo-1541369487638-7060624fd2fa?auto=format&fit=crop&w=1400&q=80",
            "Mangrove nights", 3, 21.2, StayAmenity.HotTub | StayAmenity.RedLightOnly)
    ]);

    public IReadOnlyList<Stay> FeaturedStays => Stays.Take(3).ToArray();

    public IReadOnlyList<Stay> FindFeatured(string? destination) => MatchDestination(FeaturedStays, destination).ToArray();

    public IReadOnlyList<Stay> FindStays(string? destination = null, int maximumBortle = 3,
        StayAmenity requiredAmenities = StayAmenity.None) =>
        MatchDestination(Stays, destination)
            .Where(stay => stay.Bortle <= maximumBortle)
            .Where(stay => (stay.Amenities & requiredAmenities) == requiredAmenities)
            .ToArray();

    private static IEnumerable<Stay> MatchDestination(IEnumerable<Stay> stays, string? destination)
    {
        if (string.IsNullOrWhiteSpace(destination))
        {
            return stays;
        }

        var query = destination.Trim();
        return stays.Where(stay =>
            stay.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
            || stay.Location.Contains(query, StringComparison.OrdinalIgnoreCase));
    }
}
