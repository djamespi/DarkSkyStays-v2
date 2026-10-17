using DarkSkyStays.Models;

namespace DarkSkyStays.Services;

/// <summary>Browser-only sample data and session state. Refreshing resets saved stays.</summary>
public sealed class SampleStayService
{
    private readonly HashSet<int> savedIds = [];

    public IReadOnlyList<Stay> Stays { get; } = Array.AsReadOnly<Stay>(
    [
        new(1, "Moonrise Cabin", "Mountain Ridge", "A quiet cabin with an open view of the night sky.", 120),
        new(2, "Starlight Dome", "Desert Valley", "A cozy dome for slow evenings under the stars.", 165),
        new(3, "Pinewood Retreat", "Forest Edge", "A woodland hideaway with a private outdoor deck.", 145)
    ]);

    public int SavedCount => savedIds.Count;
    public bool IsSaved(int id) => savedIds.Contains(id);

    public void ToggleSaved(int id)
    {
        if (!savedIds.Add(id))
        {
            savedIds.Remove(id);
        }
    }
}
