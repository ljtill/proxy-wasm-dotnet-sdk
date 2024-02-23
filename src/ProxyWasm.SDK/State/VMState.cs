namespace ProxyWasm.SDK;

/// <summary>
/// VMState is a helper class to set the VMContext.
/// </summary>
public class VMState
{
    public ContextState contextState;

    public void SetVMContext(IVMContext context)
    {
        contextState.VMContext = context;
    }

    public void RegisterHttpCallout(uint calloutId, Action<int, int, int> callback)
    {
        contextState.RegisterHttpCallOut(calloutId, callback);
    }
}

/// <summary>
/// PluginContextState is a class to hold the current plugin context and the http callbacks.
/// </summary>
public class PluginContextState
{
    public IPluginContext? Context { get; set; }
    public Dictionary<uint, HttpCallbackAttribute> HttpCallbacks { get; set; } = [];
}

/// <summary>
/// HttpCallbackAttribute is a class to hold the callback function and the caller context id.
/// </summary>
public class HttpCallbackAttribute
{
    public Action<int, int, int>? Callback { get; set; }
    public uint CallerContextId { get; set; }
}
