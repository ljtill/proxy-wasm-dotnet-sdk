namespace ProxyWasm.SDK;

public class ProxyHostTcpCallback
{
    //export proxy_on_new_connection
    public static ActionType ProxyOnNewConnection(ContextState currentContextState, uint contextId)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnNewConnection();
    }

    //export proxy_on_downstream_data
    public static ActionType ProxyOnDownstreamData(ContextState currentContextState, uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnDownstreamData(dataSize, endOfStream);
    }

    //export proxy_on_downstream_connection_close
    public static void ProxyOnDownstreamConnectionClose(ContextState contextState, uint contextId, PeerType peerType)
    {
        var tcpContext = contextState.TcpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        tcpContext.OnDownstreamClose(peerType);
    }

    //export proxy_on_upstream_data
    public static ActionType ProxyOnUpstreamData(ContextState currentContextState, uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnUpstreamData(dataSize, endOfStream);
    }

    //export proxy_on_upstream_connection_close
    public static void ProxyOnUpstreamConnectionClose(ContextState currentContextState, uint contextId, PeerType peerType)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        tcpContext.OnUpstreamClose(peerType);
    }
}