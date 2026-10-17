namespace DarkSkyStays.Models;

public sealed record Stay(
    int Id,
    string Name,
    string Location,
    int NightlyRate,
    string ImageUrl,
    string Tag,
    int Bortle,
    double SkyQuality,
    StayAmenity Amenities = StayAmenity.None);
