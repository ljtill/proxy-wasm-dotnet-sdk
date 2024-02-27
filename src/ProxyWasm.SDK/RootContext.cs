namespace ProxyWasm.SDK;

public class RootContext
{
    private static RootContext? instance = null;
    public IVMContext VMContext { get; set; }
    public Dictionary<uint, PluginContextState> PluginContexts { get; set; }
    public Dictionary<uint, IHttpContext> HttpContexts { get; set; }
    public Dictionary<uint, ITcpContext> TcpContexts { get; set; }
    public Dictionary<uint, uint> ContextIdToRootId { get; }
    public uint ActiveContextId { get; set; }

    private RootContext()
    {
        VMContext = new DefaultVMContext();
        PluginContexts = [];
        TcpContexts = [];
        HttpContexts = [];
        ContextIdToRootId = [];
    }

    public static RootContext Instance
    {
        get
        {
            instance ??= new RootContext();
            return instance;
        }
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

    public void RegisterHttpCallOut(uint calloutId, Action<int, int, int> callback)
    {
        var pluginContext = PluginContexts[ContextIdToRootId[ActiveContextId]];
        pluginContext.HttpCallbacks[calloutId] = new HttpCallbackAttribute
        {
            Callback = callback,
            CallerContextId = ActiveContextId
        };
    }

    public void SetActiveContextId(uint contextId)
    {
        ActiveContextId = contextId;
    }

    public void SetVMContext(IVMContext vmContext)
    {
        VMContext = vmContext;
    }
}

public class PluginContextState
{
    public required IPluginContext Context { get; set; }
    public Dictionary<uint, HttpCallbackAttribute> HttpCallbacks { get; set; } = [];
}

public class HttpCallbackAttribute
{
    public required Action<int, int, int> Callback { get; set; }
    public uint CallerContextId { get; set; }
}
