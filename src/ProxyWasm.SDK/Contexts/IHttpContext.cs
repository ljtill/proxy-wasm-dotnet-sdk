namespace ProxyWasm.SDK;

/// <summary>
/// IHttpContext is the interface for HTTP context.
/// </summary>
public interface IHttpContext
{
    public ActionType OnRequestHeaders(int numHeaders, bool endOfStream);

    public ActionType OnRequestBody(int bodySize, bool endOfStream);

    public ActionType OnRequestTrailers(int numTrailers);

    public ActionType OnResponseHeaders(int numHeaders, bool endOfStream);

    public ActionType OnResponseBody(int bodySize, bool endOfStream);

    public ActionType OnResponseTrailers(int numHeaders);

    public void OnStreamDone();
}
