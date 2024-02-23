namespace ProxyWasm.SDK;

public interface IVMContext
{
    public OnVMStartType OnVMStart(int vmConfigurationSize);

    public IPluginContext NewPluginContext(uint contextID);
}
