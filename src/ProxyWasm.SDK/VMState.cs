namespace ProxyWasm.SDK;

/// <summary>
/// VMState is a helper class to set the VMContext.
/// </summary>
public class VMState
{
    public ContextState contextState = new();

    public void SetVMContext(IVMContext context)
    {
        contextState.VMContext = context;
    }

    public void RegisterHttpCallout(uint calloutId, Action<int, int, int> callback)
    {
        contextState.RegisterHttpCallOut(calloutId, callback);
    }
}
