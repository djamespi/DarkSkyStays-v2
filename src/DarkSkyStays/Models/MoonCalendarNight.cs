namespace DarkSkyStays.Models;

public sealed record MoonCalendarNight(DateOnly Date, MoonPhase Phase)
{
    // Match the source's strict threshold before display rounding.
    public bool IsPrimeDark => Phase.Illumination < 0.15;
}
