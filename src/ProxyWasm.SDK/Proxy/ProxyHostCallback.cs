namespace ProxyWasm.SDK;

public class ProxyHostCallback
{
    //export proxy_on_memory_allocate
    public static byte ProxyOnMemoryAllocate(uint size)
    {
        byte[] bytes = new byte[size];
        return bytes[0];
    }

    //export proxy_on_vm_start
    public static OnVMStartType ProxyOnVMStart(ContextState currentContextState, int vmConfigurationSize)
    {
        return currentContextState.VMContext.OnVMStart(vmConfigurationSize);
    }

    //export proxy_on_configure
    public static OnPluginStartType ProxyOnConfigure(ContextState currentContextState, uint pluginContextId, int pluginConfigurationSize)
    {
        var pluginContext = currentContextState.PluginContexts[pluginContextId];
        currentContextState.SetActiveContextId(pluginContextId);

        return pluginContext.Context.OnPluginStart(pluginConfigurationSize);
    }

    //export proxy_on_context_create
    public static void ProxyOnContextCreate()
    {

    }

    //export proxy_on_log
    public static void ProxyOnLog()
    {

    }

    //export proxy_on_done
    public static void ProxyOnDone()
    {

    }

    //export proxy_on_delete
    public static void ProxyOnDelete()
    {

    }

    //export proxy_on_queue_ready
    public static void ProxyOnQueueReady()
    {

    }

    //export proxy_on_tick
    public static void ProxyOnTick()
    {

    }

    //export proxy_abi_version_0_2_0
    public static void ProxyABIVersion()
    {

    }
}
