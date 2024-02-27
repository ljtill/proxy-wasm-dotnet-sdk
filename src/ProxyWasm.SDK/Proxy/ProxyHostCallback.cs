using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

public static class ProxyHostCallback
{
    private static readonly RootContext rootContext = RootContext.Instance;

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_memory_allocate")]
    static byte ProxyOnMemoryAllocate(uint size)
    {
        byte[] bytes = new byte[size];
        return bytes[0];
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_vm_start")]
    static OnVMStartType ProxyOnVMStart(int vmConfigurationSize)
    {
        return rootContext.VMContext.OnVMStart(vmConfigurationSize);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_configure")]
    static OnPluginStartType ProxyOnConscfigure(uint pluginContextId, int pluginConfigurationSize)
    {
        var pluginContext = rootContext.PluginContexts[pluginContextId];
        rootContext.SetActiveContextId(pluginContextId);

        return pluginContext.Context.OnPluginStart(pluginConfigurationSize);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_context_create")]
    static void ProxyOnContextCreate(uint contextId, uint pluginContextId)
    {
        if (pluginContextId == 0)
        {
            rootContext.CreatePluginContext(contextId);
        }
        else if (rootContext.CreateHttpContext(contextId, pluginContextId))
        { }
        else if (rootContext.CreateTcpContext(contextId, pluginContextId))
        { }
        else
        {
            throw new Exception("Invalid context id on proxy_on_context_create");
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_log")]
    static void ProxyOnLog(uint contextId)
    {
        var tcpContext = rootContext.TcpContexts[contextId];
        if (tcpContext != null)
        {
            rootContext.SetActiveContextId(contextId);
            tcpContext.OnStreamDone();
        }

        var httpContext = rootContext.HttpContexts[contextId];
        if (httpContext != null)
        {
            rootContext.SetActiveContextId(contextId);
            httpContext.OnStreamDone();
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_done")]
    static bool ProxyOnDone(uint contextId)
    {
        var pluginContext = rootContext.PluginContexts[contextId];
        if (pluginContext != null)
        {
            rootContext.SetActiveContextId(contextId);
            return pluginContext.Context.OnPluginDone();
        }

        return true;
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_delete")]
    static void ProxyOnDelete(uint contextId)
    {
        rootContext.ContextIdToRootId.Remove(contextId);
        rootContext.TcpContexts.Remove(contextId);
        rootContext.HttpContexts.Remove(contextId);
        rootContext.PluginContexts.Remove(contextId);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_queue_ready")]
    static void ProxyOnQueueReady(uint queueId)
    {
        var pluginContext = rootContext.PluginContexts[queueId];
        rootContext.SetActiveContextId(queueId);

        pluginContext.Context.OnQueueReady(queueId);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_tick")]
    static void ProxyOnTick(uint pluginContextId)
    {
        var pluginContext = rootContext.PluginContexts[pluginContextId];
        rootContext.SetActiveContextId(pluginContextId);

        pluginContext.Context.OnTick();
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_abi_version_0_2_0")]
    static void ProxyABIVersion() { }
}
