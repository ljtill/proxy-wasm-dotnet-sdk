namespace ProxyWasm.SDK;

/// <summary>
/// IHttpContext is the interface for HTTP context.
/// </summary>
public interface IHttpContext
{
    public uint OnHttpRequestHeaders(int numHeaders, bool endOfStream);

    public uint OnHttpRequest(int bodySize, bool endOfStream);

    public uint OnHttpRequestTrailers(int numTrailers);

    public uint OnHttpResponseHeaders(int numHeaders, bool endOfStream);

    public uint OnHttpResponseTrailers(int numHeaders);

    public void OnHttpStreamDone();
}