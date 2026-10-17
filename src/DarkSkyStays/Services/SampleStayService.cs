using DarkSkyStays.Models;

namespace DarkSkyStays.Services;

/// <summary>Sample listings from the Figma Make Home page. No availability or booking backend.</summary>
public sealed class SampleStayService
{
    public const string HeroImageUrl = "https://images.unsplash.com/photo-1623390003557-1b1c4f7c9a4e?auto=format&fit=crop&w=1400&q=80";

    public IReadOnlyList<Stay> Stays { get; } = Array.AsReadOnly<Stay>(
    [
        new(1, "Sagada Pine Cabin", "Sagada, Mountain Province", 4500,
            "https://images.unsplash.com/photo-1786676886005-b819eeee3b32?auto=format&fit=crop&w=1400&q=80",
            "Cordillera highlands", 2, 21.6),
        new(2, "Batanes Stone House", "Sabtang, Batanes", 6800,
            "https://images.unsplash.com/photo-1738004659538-7648e412b3df?auto=format&fit=crop&w=1400&q=80",
            "Darkest in the country", 1, 21.9),
        new(3, "Nipa & Comet Lodge", "Balabac, Palawan", 5900,
            "https://images.unsplash.com/photo-1695413120140-07575da6eab5?auto=format&fit=crop&w=1400&q=80",
            "Remote island skies", 1, 21.8)
    ]);

    public IReadOnlyList<Stay> FindFeatured(string? destination)
    {
        if (string.IsNullOrWhiteSpace(destination))
        {
            return Stays;
        }

        var query = destination.Trim();
        return Stays.Where(stay =>
            stay.Name.Contains(query, StringComparison.OrdinalIgnoreCase)
            || stay.Location.Contains(query, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
