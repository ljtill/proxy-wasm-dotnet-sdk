namespace ProxyWasm.SDK;

public interface ITcpContext
{
    public ActionType OnNewConnection();

    public ActionType OnDownstreamData(int dataSize, bool endOfStream);

    public void OnDownstreamClose(PeerType peerType);

    public ActionType OnUpstreamData(int dataSize, bool endOfStream);

    public void OnUpstreamClose(PeerType peerType);

    public void OnStreamDone();
}
