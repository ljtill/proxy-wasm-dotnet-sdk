using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

static class ProxyHostCallback
{
    [UnmanagedCallersOnly(EntryPoint = "proxy_on_memory_allocate")]
    static byte ProxyOnMemoryAllocate(uint size)
    {
        byte[] bytes = new byte[size];
        return bytes[0];
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_vm_start")]
    static OnVMStartType ProxyOnVMStart(RootContext currentContextState, int vmConfigurationSize)
    {
        return currentContextState.VMContext.OnVMStart(vmConfigurationSize);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_configure")]
    static OnPluginStartType ProxyOnConscfigure(RootContext currentContextState, uint pluginContextId, int pluginConfigurationSize)
    {
        var pluginContext = currentContextState.PluginContexts[pluginContextId];
        currentContextState.SetActiveContextId(pluginContextId);

        return pluginContext.Context.OnPluginStart(pluginConfigurationSize);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_context_create")]
    static void ProxyOnContextCreate(RootContext contextState, uint contextId, uint pluginContextId)
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

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_log")]
    static void ProxyOnLog(RootContext contextState, uint contextId)
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

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_done")]
    static bool ProxyOnDone(RootContext contextState, uint contextId)
    {
        var pluginContext = contextState.PluginContexts[contextId];
        if (pluginContext != null)
        {
            contextState.SetActiveContextId(contextId);
            return pluginContext.Context.OnPluginDone();
        }

        return true;
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_delete")]
    static void ProxyOnDelete(RootContext contextState, uint contextId)
    {
        contextState.ContextIdToRootId.Remove(contextId);
        contextState.TcpContexts.Remove(contextId);
        contextState.HttpContexts.Remove(contextId);
        contextState.PluginContexts.Remove(contextId);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_queue_ready")]
    static void ProxyOnQueueReady(RootContext contextState, uint queueId)
    {
        var pluginContext = contextState.PluginContexts[queueId];
        contextState.SetActiveContextId(queueId);

        pluginContext.Context.OnQueueReady(queueId);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_tick")]
    static void ProxyOnTick(RootContext contextState, uint pluginContextId)
    {
        var pluginContext = contextState.PluginContexts[pluginContextId];
        contextState.SetActiveContextId(pluginContextId);

        pluginContext.Context.OnTick();
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_abi_version_0_2_0")]
    static void ProxyABIVersion() { }
}
