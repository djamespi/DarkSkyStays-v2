namespace DarkSkyStays.Services;

/// <summary>Signals navigation from prototype controls to the migrated pages.</summary>
public sealed class PrototypeNavigation
{
    public event Action<Models.PrototypePage>? PageRequested;

    public void RequestPage(Models.PrototypePage page) => PageRequested?.Invoke(page);
}
