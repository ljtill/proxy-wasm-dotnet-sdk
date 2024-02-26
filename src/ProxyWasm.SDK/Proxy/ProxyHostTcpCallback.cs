using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

class ProxyHostTcpCallback
{
    [UnmanagedCallersOnly(EntryPoint = "proxy_on_new_connection")]
    static ActionType ProxyOnNewConnection(RootContext currentContextState, uint contextId)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnNewConnection();
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_downstream_data")]
    static ActionType ProxyOnDownstreamData(RootContext currentContextState, uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnDownstreamData(dataSize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_downstream_connection_close")]
    static void ProxyOnDownstreamConnectionClose(RootContext contextState, uint contextId, PeerType peerType)
    {
        var tcpContext = contextState.TcpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        tcpContext.OnDownstreamClose(peerType);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_upstream_data")]
    static ActionType ProxyOnUpstreamData(RootContext currentContextState, uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return tcpContext.OnUpstreamData(dataSize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_upstream_connection_close")]
    static void ProxyOnUpstreamConnectionClose(RootContext currentContextState, uint contextId, PeerType peerType)
    {
        var tcpContext = currentContextState.TcpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        tcpContext.OnUpstreamClose(peerType);
    }
}
