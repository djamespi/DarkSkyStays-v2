namespace DarkSkyStays.Models;

public sealed record MoonPhase(double Age, double Illumination, string Name)
{
    public int IlluminationPercent => (int)Math.Floor(Illumination * 100 + 0.5);
}
