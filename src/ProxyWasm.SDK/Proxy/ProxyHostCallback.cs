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
    public static OnVMStartType ProxyOnVMStart(RootContext currentContextState, int vmConfigurationSize)
    {
        return currentContextState.VMContext.OnVMStart(vmConfigurationSize);
    }

    //export proxy_on_configure
    public static OnPluginStartType ProxyOnConfigure(RootContext currentContextState, uint pluginContextId, int pluginConfigurationSize)
    {
        var pluginContext = currentContextState.PluginContexts[pluginContextId];
        currentContextState.SetActiveContextId(pluginContextId);

        return pluginContext.Context.OnPluginStart(pluginConfigurationSize);
    }

    //export proxy_on_context_create
    public static void ProxyOnContextCreate(RootContext contextState, uint contextId, uint pluginContextId)
    {
        if (pluginContextId == 0)
        {
            contextState.CreatePluginContext(contextId);
        }
        else if (contextState.CreateHttpContext(contextId, pluginContextId))
        { }
        else if (contextState.CreateTcpContext(contextId, pluginContextId))
        { }
        else
        {
            throw new Exception("Invalid context id on proxy_on_context_create");
        }
    }

    //export proxy_on_log
    public static void ProxyOnLog(RootContext contextState, uint contextId)
    {
        var tcpContext = contextState.TcpContexts[contextId];
        if (tcpContext != null)
        {
            contextState.SetActiveContextId(contextId);
            tcpContext.OnStreamDone();
        }

        var httpContext = contextState.HttpContexts[contextId];
        if (httpContext != null)
        {
            contextState.SetActiveContextId(contextId);
            httpContext.OnStreamDone();
        }
    }

    //export proxy_on_done
    public static bool ProxyOnDone(RootContext contextState, uint contextId)
    {
        var pluginContext = contextState.PluginContexts[contextId];
        if (pluginContext != null)
        {
            contextState.SetActiveContextId(contextId);
            return pluginContext.Context.OnPluginDone();
        }

        return true;
    }

    //export proxy_on_delete
    public static void ProxyOnDelete(RootContext contextState, uint contextId)
    {
        contextState.ContextIdToRootId.Remove(contextId);
        contextState.TcpContexts.Remove(contextId);
        contextState.HttpContexts.Remove(contextId);
        contextState.PluginContexts.Remove(contextId);

        // TODO: Implement
    }

    //export proxy_on_queue_ready
    public static void ProxyOnQueueReady(RootContext contextState, uint queueId)
    {
        var pluginContext = contextState.PluginContexts[queueId];
        contextState.SetActiveContextId(queueId);

        pluginContext.Context.OnQueueReady(queueId);
    }

    //export proxy_on_tick
    public static void ProxyOnTick(RootContext contextState, uint pluginContextId)
    {
        var pluginContext = contextState.PluginContexts[pluginContextId];
        contextState.SetActiveContextId(pluginContextId);

        pluginContext.Context.OnTick();
    }

    //export proxy_abi_version_0_2_0
    public static void ProxyABIVersion() { }
}
