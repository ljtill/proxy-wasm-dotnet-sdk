namespace ProxyWasm.SDK;

/// <summary>
/// IVMContext is the interface for VM context.
/// </summary>
public interface IVMContext
{
    public OnVMStartType OnVMStart(int vmConfigurationSize);

    public IPluginContext NewPluginContext(uint contextID);
}
