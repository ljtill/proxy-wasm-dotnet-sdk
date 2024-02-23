namespace ProxyWasm.SDK;

/// <summary>
/// State is a class to hold the current state of the VM.
/// </summary>
public class ContextState
{
    public IVMContext? VMContext { get; set; }
    public Dictionary<uint, PluginContextState> PluginContexts { get; set; } = [];
    public Dictionary<uint, ITcpContext> TcpContexts { get; set; } = [];
    public Dictionary<uint, IHttpContext> HttpContexts { get; set; } = [];

    public Dictionary<uint, uint> ContextIdToRootId { get; } = [];
    public uint ActiveContextId { get; set; }

    public void RegisterHttpCallOut(uint calloutId, Action<int, int, int> callback)
    {
        var pluginContext = PluginContexts[ContextIdToRootId[ActiveContextId]];
        pluginContext.HttpCallbacks[calloutId] = new HttpCallbackAttribute
        {
            Callback = callback,
            CallerContextId = ActiveContextId
        };
    }

    public void CreatePluginContext(uint contextId)
    {
        var context = VMContext.NewPluginContext(contextId);
        PluginContexts[contextId] = new PluginContextState
        {
            Context = context,
            HttpCallbacks = []
        };
    }

    public bool CreateTcpContext(uint contextId, uint pluginContextId)
    {
        var pluginContext = PluginContexts[pluginContextId];
        _ = TcpContexts[contextId];

        var tcpContext = pluginContext.Context.NewTcpContext(contextId);
        ContextIdToRootId[contextId] = pluginContextId;
        TcpContexts[contextId] = tcpContext;

        return true;
    }

    public bool CreateHttpContext(uint contextId, uint pluginContextId)
    {
        var pluginContext = PluginContexts[pluginContextId];
        _ = HttpContexts[contextId];

        var httpContext = pluginContext.Context.NewHttpContext(contextId);
        ContextIdToRootId[contextId] = pluginContextId;
        HttpContexts[contextId] = httpContext;

        return true;
    }

    public void SetActiveContextId(uint contextId)
    {
        ActiveContextId = contextId;
    }
}