namespace ProxyWasm.SDK;

/// <summary>
/// DefaultVMContext is the default implementation of IVMContext.
/// </summary>
public class DefaultVMContext : IVMContext
{
    public bool OnVMStart(int vmConfigurationSize)
    {
        return OnVMStartType.StartStatusOK;
    }

    public IPluginContext NewPluginContext(uint contextID)
    {
        return new DefaultPluginContext();
    }
}

/// <summary>
/// DefaultPluginContext is the default implementation of IPluginContext.
/// </summary>
public class DefaultPluginContext : IPluginContext
{
    public bool OnPluginStart(int pluginConfigurationSize)
    {
        return OnPluginStartType.StartStatusOK;
    }

    public bool OnPluginDone()
    {
        return true;
    }

    public void OnQueueReady(uint queueID)
    {
    }

    public void OnTick()
    {
    }

    public ITcpContext? NewTcpContext(uint contextID)
    {
        return null;
    }

    public IHttpContext? NewHttpContext(uint contextID)
    {
        return null;
    }
}

/// <summary>
/// DefaultTcpContext is the default implementation of ITcpContext.
/// </summary>
public class DefaultTcpContext : ITcpContext
{
    public uint OnNewConnection()
    {
        return ActionType.Continue;
    }

    public uint OnDownstreamData(int dataSize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public void OnDownstreamClose(PeerType peerType)
    {
    }

    public uint OnUpstreamData(int dataSize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public void OnUpstreamClose(PeerType peerType)
    {
    }

    public void OnStreamDone()
    {
    }
}

/// <summary>
/// DefaultHttpContext is the default implementation of IHttpContext.
/// </summary>
public class DefaultHttpContext : IHttpContext
{
    public uint OnHttpRequestHeaders(int numHeaders, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public uint OnHttpRequest(int bodySize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public uint OnHttpRequestTrailers(int numTrailers)
    {
        return ActionType.Continue;
    }

    public uint OnHttpResponseHeaders(int numHeaders, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public uint OnHttpResponseTrailers(int numHeaders)
    {
        return ActionType.Continue;
    }

    public void OnStreamDone()
    {
    }
}
