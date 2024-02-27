using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

static class ProxyHostHttpCallback
{
    private static readonly RootContext rootContext = RootContext.Instance;

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_headers")]
    static ActionType ProxyOnRequestHeaders(uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return httpContext.OnRequestHeaders(numberHeaders, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_body")]
    static ActionType ProxyOnRequestBody(uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return httpContext.OnRequestBody(bodySize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_trailers")]
    static ActionType ProxyOnRequestTrailers(uint contextId, int numberTrailers)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return httpContext.OnRequestTrailers(numberTrailers);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_headers")]
    static ActionType ProxyOnResponseHeaders(uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return httpContext.OnResponseHeaders(numberHeaders, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_body")]
    static ActionType ProxyOnResponseBody(uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        return httpContext.OnResponseBody(bodySize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_trailers")]
    static void ProxyOnResponseTrailers(uint contextId, int numberTrailers)
    {
        var httpContext = rootContext.HttpContexts[contextId];
        rootContext.SetActiveContextId(contextId);

        httpContext.OnResponseTrailers(numberTrailers);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_http_call_response")]
    static void ProxyOnHttpCallResponse(uint pluginContextId, uint calloutId, int numHeaders, int bodySize, int numTrailers)
    {
        var pluginContext = rootContext.PluginContexts[pluginContextId];
        var httpCallback = pluginContext.HttpCallbacks[calloutId];

        var callerContextId = httpCallback.CallerContextId;
        rootContext.SetActiveContextId(callerContextId);

        var httpCallbacks = pluginContext.HttpCallbacks;
        httpCallbacks.Remove(calloutId);

        if (rootContext.ContextIdToRootId.ContainsKey(callerContextId))
        {
            ProxyHost.ProxySetEffectiveContext(callerContextId);
            httpCallback.Callback(numHeaders, bodySize, numTrailers);
        }
    }
}
