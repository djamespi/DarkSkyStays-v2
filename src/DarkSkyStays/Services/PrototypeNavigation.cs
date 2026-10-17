namespace DarkSkyStays.Services;

/// <summary>Signals navigation to pages awaiting their separate migration and review.</summary>
public sealed class PrototypeNavigation
{
    public event Action<Models.PrototypePage>? PageRequested;

    public void RequestPage(Models.PrototypePage page) => PageRequested?.Invoke(page);
}
