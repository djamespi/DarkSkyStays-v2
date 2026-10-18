namespace DarkSkyStays.Models;

public sealed record Tour(
    int Id,
    string Name,
    string Location,
    string TimeWindow,
    int PricePerPerson,
    string Guide,
    string ImageUrl);
