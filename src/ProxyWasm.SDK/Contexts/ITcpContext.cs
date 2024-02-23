namespace ProxyWasm.SDK;

/// <summary>
/// ITcpContext is the interface for TCP context.
/// </summary>
public interface ITcpContext
{
    public uint OnNewConnection();

    public uint OnDownstreamData(int dataSize, bool endOfStream);

    public void OnDownstreamClose(PeerType peerType);

    public uint OnUpstreamData(int dataSize, bool endOfStream);

    public void OnUpstreamClose(PeerType peerType);

    public void OnStreamDone();
}