namespace ProxyWasm.SDK;

public class DefaultVMContext : IVMContext
{
    public OnVMStartType OnVMStart(int vmConfigurationSize)
    {
        return OnVMStartType.StartStatusOK;
    }

    public IPluginContext NewPluginContext(uint contextID)
    {
        return new DefaultPluginContext();
    }
}

public class DefaultPluginContext : IPluginContext
{
    public OnPluginStartType OnPluginStart(int pluginConfigurationSize)
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

    public ITcpContext NewTcpContext(uint contextID)
    {
        return new DefaultTcpContext();
    }

    public IHttpContext NewHttpContext(uint contextID)
    {
        return new DefaultHttpContext();
    }
}

public class DefaultTcpContext : ITcpContext
{
    public ActionType OnNewConnection()
    {
        return ActionType.Continue;
    }

    public ActionType OnDownstreamData(int dataSize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public void OnDownstreamClose(PeerType peerType)
    {
    }

    public ActionType OnUpstreamData(int dataSize, bool endOfStream)
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

public class DefaultHttpContext : IHttpContext
{
    public ActionType OnRequestHeaders(int numHeaders, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public ActionType OnRequestBody(int bodySize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public ActionType OnRequestTrailers(int numTrailers)
    {
        return ActionType.Continue;
    }

    public ActionType OnResponseHeaders(int numHeaders, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public ActionType OnResponseBody(int bodySize, bool endOfStream)
    {
        return ActionType.Continue;
    }

    public ActionType OnResponseTrailers(int numHeaders)
    {
        return ActionType.Continue;
    }

    public void OnStreamDone()
    {
    }
}
