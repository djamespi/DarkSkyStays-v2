using DarkSkyStays.Models;

namespace DarkSkyStays.Services;

/// <summary>Matches the approximate synodic-month calculation in the Figma Make source.</summary>
public static class MoonPhaseService
{
    public const double SynodicMonth = 29.530588853;
    private static readonly DateTimeOffset ReferenceNewMoon = new(2000, 1, 6, 18, 14, 0, TimeSpan.Zero);
    private static readonly string[] Names =
    [
        "New Moon", "Waxing Crescent", "First Quarter", "Waxing Gibbous",
        "Full Moon", "Waning Gibbous", "Last Quarter", "Waning Crescent"
    ];

    public static MoonPhase Calculate(DateTimeOffset instant)
    {
        var days = (instant - ReferenceNewMoon).TotalDays;
        var age = ((days % SynodicMonth) + SynodicMonth) % SynodicMonth;
        var illumination = (1 - Math.Cos(2 * Math.PI * age / SynodicMonth)) / 2;
        var phaseIndex = (int)Math.Floor(age / SynodicMonth * 8 + 0.5) % Names.Length;
        return new(age, illumination, Names[phaseIndex]);
    }

    /// <summary>Uses local calendar days, preserving the source's time of day.</summary>
    public static IReadOnlyList<MoonCalendarNight> GetUpcomingNights(DateTime localStart)
    {
        return Enumerable.Range(0, 30).Select(offset =>
        {
            var localNight = localStart.AddDays(offset);
            return new MoonCalendarNight(
                DateOnly.FromDateTime(localNight),
                Calculate(new DateTimeOffset(localNight)));
        }).ToArray();
    }
}
