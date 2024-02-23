namespace ProxyWasm.SDK;

/// <summary>
/// IPluginContext is the interface for plugin context.
/// </summary>
public interface IPluginContext
{
    public OnPluginStartType OnPluginStart(int pluginConfigurationSize);

    public bool OnPluginDone();

    public void OnQueueReady(uint queueID);

    public void OnTick();

    public ITcpContext NewTcpContext(uint contextID);

    public IHttpContext NewHttpContext(uint contextID);
}
