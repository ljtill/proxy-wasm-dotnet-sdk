namespace ProxyWasm.SDK;

public class ProxyHostHttpCallback
{
    //export proxy_on_request_headers
    public static ActionType ProxyOnRequestHeaders(RootContext currentContextState, uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = currentContextState.HttpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return httpContext.OnRequestHeaders(numberHeaders, endOfStream);
    }

    //export proxy_on_request_body
    public static ActionType ProxyOnRequestBody(RootContext currentContextState, uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = currentContextState.HttpContexts[contextId];
        currentContextState.SetActiveContextId(contextId);

        return httpContext.OnRequestBody(bodySize, endOfStream);
    }

    //export proxy_on_request_trailers
    public static ActionType ProxyOnRequestTrailers(RootContext contextState, uint contextId, int numberTrailers)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnRequestTrailers(numberTrailers);
    }

    //export proxy_on_response_headers
    public static ActionType ProxyOnResponseHeaders(RootContext contextState, uint contextId, int numberHeaders, bool endOfStream)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnResponseHeaders(numberHeaders, endOfStream);
    }


    //export proxy_on_response_body
    public static ActionType ProxyOnResponseBody(RootContext contextState, uint contextId, int bodySize, bool endOfStream)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        return httpContext.OnResponseBody(bodySize, endOfStream);
    }

    //export proxy_on_response_trailers
    public static void ProxyOnResponseTrailers(RootContext contextState, uint contextId, int numberTrailers)
    {
        var httpContext = contextState.HttpContexts[contextId];
        contextState.SetActiveContextId(contextId);

        httpContext.OnResponseTrailers(numberTrailers);
    }

    //export proxy_on_http_call_response
    public static void ProxyOnHttpCallResponse(RootContext contextState, uint pluginContextId, uint calloutId, int numHeaders, int bodySize, int numTrailers)
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
