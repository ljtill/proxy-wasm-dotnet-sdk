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
    Unknown = 0,
    Local = 1,
    Remote = 2
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
    Trace = 0,
    Debug = 1,
    Information = 2,
    Warning = 3,
    Error = 4,
    Critical = 5,
    Max = 6
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
    Request = 0,
    Response = 1,
    Downstream = 2,
    Upstream = 3
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
