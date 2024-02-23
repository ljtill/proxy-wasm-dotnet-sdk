namespace ProxyWasm.SDK;

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
