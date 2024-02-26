namespace ProxyWasm.SDK;

public class State
{
    public RootContext RootContext { get; set; }

    public State()
    {
        RootContext = new RootContext();
    }

    public void SetVMContext(IVMContext vmContext)
    {
        RootContext.VMContext = vmContext;
    }

    public void RegisterHttpCallOut(uint calloutId, Action<int, int, int> callback)
    {
        RootContext.RegisterHttpCallOut(calloutId, callback);
    }
}
