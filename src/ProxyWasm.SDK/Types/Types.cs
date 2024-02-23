namespace ProxyWasm.SDK;

public enum OnVMStartType
{
    StartStatusOK = 0,
    StartStatusFailed = 1
}

public enum OnPluginStartType
{
    StartStatusOK = 0,
    StartStatusFailed = 1
}

public enum ActionType
{
    Continue = 0,
    Pause = 1
}

public enum PeerType
{
    PeerTypeUnknown = 0,
    PeerTypeLocal = 1,
    PeerTypeRemote = 2
}

public enum BufferType
{
    HttpRequestBody = 0,
    HttpResponseBody = 1,
    DownstreamData = 2,
    UpstreamData = 3,
    HttpCallResponseBody = 4,
    GrpcReceiveBuffer = 5,
    VMConfiguration = 6,
    PluginConfiguration = 7,
    CallData = 8
}

public enum LogLevelType
{
    LogLevelTrace = 0,
    LogLevelDebug = 1,
    LogLevelInfo = 2,
    LogLevelWarn = 3,
    LogLevelError = 4,
    LogLevelCritical = 5,
    LogLevelMax = 6
}

public enum MapType
{
    HttpRequestHeaders = 0,
    HttpRequestTrailers = 1,
    HttpResponseHeaders = 2,
    HttpResponseTrailers = 3,
    HttpCallResponseHeaders = 6,
    HttpCallResponseTrailers = 7
}

public enum MetricType
{
    Counter = 0,
    Gauge = 1,
    Histogram = 2
}

public enum StreamType
{
    StreamRequest = 0,
    StreamResponse = 1,
    StreamDownstream = 2,
    StreamUpstream = 3
}

public enum StatusType
{
    OK = 0,
    NotFound = 1,
    BadArgument = 2,
    Empty = 7,
    CasMismatch = 8,
    InternalFailure = 10,
    Unimplemented = 12
}
