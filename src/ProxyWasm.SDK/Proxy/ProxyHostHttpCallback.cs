using System.Runtime.InteropServices;

namespace ProxyWasm.SDK;

class ProxyHostHttpCallback
{
    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_headers")]
    static ActionType ProxyOnRequestHeaders(RootContext currentContextState, uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = currentContextState.HttpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return httpContext.OnRequestHeaders(numberHeaders, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_body")]
    static ActionType ProxyOnRequestBody(RootContext currentContextState, uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = currentContextState.HttpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return httpContext.OnRequestBody(bodySize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_request_trailers")]
    static ActionType ProxyOnRequestTrailers(RootContext contextState, uint contextId, int numberTrailers)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnRequestTrailers(numberTrailers);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_headers")]
    static ActionType ProxyOnResponseHeaders(RootContext contextState, uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnResponseHeaders(numberHeaders, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_body")]
    static ActionType ProxyOnResponseBody(RootContext contextState, uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnResponseBody(bodySize, endOfStream);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_response_trailers")]
    static void ProxyOnResponseTrailers(RootContext contextState, uint contextId, int numberTrailers)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        httpContext.OnResponseTrailers(numberTrailers);
    }

    [UnmanagedCallersOnly(EntryPoint = "proxy_on_http_call_response")]
    static void ProxyOnHttpCallResponse(RootContext contextState, uint pluginContextId, uint calloutId, int numHeaders, int bodySize, int numTrailers)
    {
        var pluginContext = contextState.PluginContexts[pluginContextId];
        var httpCallback = pluginContext.HttpCallbacks[calloutId];

        var callerContextId = httpCallback.CallerContextId;
        contextState.SetActiveContextId(callerContextId);

        var httpCallbacks = pluginContext.HttpCallbacks;
        httpCallbacks.Remove(calloutId);

        if (contextState.ContextIdToRootId.ContainsKey(callerContextId))
        {
            ProxyHost.ProxySetEffectiveContext(callerContextId);
            httpCallback.Callback(numHeaders, bodySize, numTrailers);
        }
    }
}
