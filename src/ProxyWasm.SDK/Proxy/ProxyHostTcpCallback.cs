using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

static class ProxyHostTcpCallback
{
    static RootContext rootContext;

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_new_connection")]
    static ActionType ProxyOnNewConnection(uint contextId)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return tcpContext.OnNewConnection();
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_downstream_data")]
    static ActionType ProxyOnDownstreamData(uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return tcpContext.OnDownstreamData(dataSize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_downstream_connection_close")]
    static void ProxyOnDownstreamConnectionClose(uint contextId, PeerType peerType)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        tcpContext.OnDownstreamClose(peerType);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_upstream_data")]
    static ActionType ProxyOnUpstreamData(uint contextId, int dataSize, bool endOfStream)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return tcpContext.OnUpstreamData(dataSize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_upstream_connection_close")]
    static void ProxyOnUpstreamConnectionClose(uint contextId, PeerType peerType)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        tcpContext.OnUpstreamClose(peerType);
    }
}
